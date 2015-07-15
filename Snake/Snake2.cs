using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Snake2:Snake
    {
        public override void Update(GameTime gameTime)
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

        enum  Direction
        {
            Up,
            Down,
            Left,
            Right
        };
    }
}
