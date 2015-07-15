﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake
    {
        public static readonly int INIT_BODY_LENGTH = 5;
        protected readonly int WIDTH = GameManager.WIDTH / GameManager.TILE_SIZE;
        protected readonly int HEIGHT = GameManager.HEIGHT / GameManager.TILE_SIZE;

        protected List<Vector2> body;
        protected Direction direction;

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
        public void BodyGrow()
        {
            body.Add(Head - (Vector2.UnitX * (body.Count + 1)));
        }

        public Snake()
        {
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

        public void Update(GameTime gameTime)
        {
            
            
            // Change snake direction
            if (InputController.IsleftPressed && direction != Direction.Right)
            {
                direction = Direction.Left;
            }
            else if (InputController.IsRightPressed && direction != Direction.Left)
            {
                direction = Direction.Right;
            }
            else if (InputController.IsDownPressed && direction != Direction.Up)
            {
                direction = Direction.Down;
            }
            else if (InputController.IsUpPressed && direction != Direction.Down)
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

        protected void Move(Vector2 amount)
        {
            // Move body
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i] = body[i - 1];
            }

            // Head moves on a direction
            body[0] += amount;
        }


        // if the snake touch the food
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

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw snake
            for (int i = 0; i < body.Count; i++)
            {
                spriteBatch.Draw(Resources.tail2, body[i] * GameManager.TILE_SIZE, Color.White);
            }
        }
    }

    protected enum Direction 
    {
        Up, 
        Down, 
        Left, 
        Right
    };
}