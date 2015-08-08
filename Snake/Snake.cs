using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake
    {
        //Begining length of snake
        private static readonly int INIT_BODY_LENGTH = 5;
        private readonly int WIDTH = GameManager.Width / GameManager.Tile_Size;
        private readonly int HEIGHT = GameManager.Height / GameManager.Tile_Size;              

        private List<Vector2> body;
        private Direction direction;

        private InputController inputController;
        private Texture2D resources;

        public Vector2 Head
        {
            get
            {
                // Return first position of body
                return body[0];
            }
        }

        public Vector2 Tail
        {
            get
            {
                // Return last position of body
                return body[body.Count - 1];
            }
        }
        public Vector2 SecondTail
        {
            get
            {
                // Return last position of body
                return body[body.Count - 2];
            }
        }

        public InputController InputController 
        {
            get { return inputController; }
        }
        
        //body grow when the nake has a food
        public void BodyGrow()
        {
            //body.Add(Head - (Vector2.UnitX * (body.Count)));
            if (Tail.X < SecondTail.X){body.Add(Tail - Vector2.UnitX);}
            else if (Tail.X > SecondTail.X) { body.Add(Tail + Vector2.UnitX); }
            else if (Tail.Y < SecondTail.Y) { body.Add(Tail - Vector2.UnitY); }
            else { body.Add(Tail + Vector2.UnitY); }       
        }

        /// <summary>
        /// Snake movment anamation
        /// </summary>
        /// <param name="inputController">give a set of keys to controller</param>
        /// <param name="resources">which texture is to draw</param>
        public Snake(InputController inputController, Texture2D resources)
        {
            this.inputController = inputController;
            this.resources = resources;

            // Initialize snake
            body = new List<Vector2>();

            // Initialize head of snake on the middle of the screen
            body.Add(new Vector2(WIDTH / 2, HEIGHT / 2));

            // body to the left of the body
            for (int i = 0; i < INIT_BODY_LENGTH; i++)
            {
                body.Add(Head - (Vector2.UnitX * (i + 1)));
            }
            
            // Initialize moving to the right
            direction = Direction.Right;
        }

        //allow sanke to keep moving in last direction
        public void Update(GameTime gameTime)
        {
            // Change snake direction
            if (inputController.IsleftPressed && direction != Direction.Right)
            {
                direction = Direction.Left;
            }
            else if (inputController.IsRightPressed && direction != Direction.Left)
            {
                direction = Direction.Right;
            }
            else if (inputController.IsDownPressed && direction != Direction.Up)
            {
                direction = Direction.Down;
            }
            else if (inputController.IsUpPressed && direction != Direction.Down)
            {
                direction = Direction.Up;
            }

            // Move snake on a direction
            switch (direction)
            {
                case Direction.Up:
                    Move(new Vector2(0, -1));
                    break;

                case Direction.Down:
                    Move(new Vector2(0, +1));
                    break;

                case Direction.Left:
                    Move(new Vector2(-1, 0));
                    break;

                case Direction.Right:
                    Move(new Vector2(+1, 0));
                    break;
            }

            // detect if the snake reach to the border 
            if (Head.X == WIDTH)
            {
                Vector2 temp;
                temp = new Vector2(0, Head.Y);
                body[0] = temp;
            }
            else if (Head.Y == HEIGHT)
            {
                Vector2 temp;
                temp = new Vector2(Head.X, 0);
                body[0] = temp;

            }
            else if (Head.X < 0)
            {
                Vector2 temp;

                temp = new Vector2(WIDTH - 1, Head.Y);
                body[0] = temp;

            }
            else if (Head.Y < 0)
            {
                Vector2 temp;

                temp = new Vector2(Head.X, HEIGHT - 1);
                body[0] = temp;
            }
        }

        private void Move(Vector2 amount)
        {
            // Move body
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }

            // Head moves on a direction
            body[0] += amount;
        }



        /// <summary>
        /// if the snake touch the food
        /// </summary>
        /// <param name="x">x coordinate</param>
        /// <param name="y">y coordinate</param>
        /// <param name="element">one part of the body</param>
        /// <returns></returns>
        public bool Collision(float x, float y,Vector2 element)
        {
            if (element.X == x && element.Y == y)
            {
                return true;
            }
            else
            {
                return false;
            }            
        }

        public bool headCollisionFlag {
            get;set;
        }
        
        /// <summary>
        ///check if head crash the body of another snake
        /// </summary>
        /// <param name="snake">the another snake</param>
        /// <returns></returns>
        public bool headNoCollision(Snake snake)
        {
            for (int i = 1; i < snake.body.Count; i++)
            {
                if ((this.Head.X == snake.body[i].X || this.Head.X == snake.Head.X) &&
                    (this.Head.Y == snake.body[i].Y|| this.Head.Y == snake.Head.Y))
                { headCollisionFlag = true; return false; }

            }
            return true;           
            
        }

        // if the snake touch the food
        public bool BodyCollision()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (Collision(Head.X, Head.Y, body[i]))
                {
                    return true;
                }
            }
            return false;
        }        
        //shot it on the screen 
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw snake
            for (int i = 0; i < body.Count; i++)
            {
                spriteBatch.Draw(resources, body[i] * GameManager.Tile_Size, Color.White);
            }
        }
    }

    enum Direction 
    {
        Up, 
        Down, 
        Left, 
        Right
    };
}
