using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class GameManager
    {
        public static readonly int HEIGHT = 480;
        public static readonly int WIDTH = 640;
        public static readonly int TILE_SIZE = 32;
        private static readonly int INTERVAL = 500;

        private Food food;
        private Snake snake, snake2;
        private InputController inputControllerP1,inputControllerP2;
        private int timeCount;
        private int score;
        int NUMBER_OF_SNAKE = 0;
        private GameTime gameTime;

        public void Initialize()
        {
            inputControllerP1 = new InputController(Keys.A, Keys.D, Keys.W, Keys.S);
            inputControllerP2 = new InputController(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
            snake = new Snake(inputControllerP1,Resources.tail2);

            food = new Food();
            timeCount = 0;
        }

        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            // Add time elapsed since last frame to counter
            timeCount += gameTime.ElapsedGameTime.Milliseconds;
            
            // Update input controller
            snake.InputController.Update();


            if (snake2 != null )
            {
                // Update sanke
                snake2.InputController.Update();
            }


            //add second snake when press insert            
            if (InputController.IsInsertPressed && NUMBER_OF_SNAKE == 0)
            {
                NUMBER_OF_SNAKE++;
                snake2 = new Snake(inputControllerP2, Resources.player2);
            }
            
            // Check if time passed is greater than the interval
            if(timeCount > INTERVAL)
            {
                
                //check collision of snake
                
                    if (snake2 != null)
                {
                    updateSnake(snake, snake2);
                }
                else
                {
                    if (!snake.BodyCollision())
                    { // Update snake
                        snake.Update(gameTime);
                    }
                }                 
                    

                
                   
               
                if ( snake2 != null)
                {
                    updateSnake(snake2, snake);
                }
                // Check collision snake food
                foodCollision(snake);
                if (snake2 != null)
                {
                    foodCollision(snake2);
                }
               
                // Clear input controller
                snake.InputController.Clear();
                if (snake2 != null)
                {
                    snake2.InputController.Clear();
                }

                // Clear counter
                timeCount = 0;
            }

        }
        //snake east food and generate a new one
        public void foodCollision(Snake snake)
        {
            bool flag = snake.Collision(food.Position.X, food.Position.Y, snake.Head);
            if (flag)
            {
                snake.BodyGrow();
                score += 1;
                do
                {
                    //food = null;
                    food = new Food();
                } while (snake.Collision(food.Position.X, food.Position.Y, snake.Head));
            }
        }

        //update the snake motion while it alive
        public void updateSnake(Snake thisSnake, Snake anotherSnake)
        {
            //check if the sanke crash the boby of itsself
            //then check if the sanke has even crashed 
            //last, check if the snake is crashing with another snake's body 
            if (!anotherSnake.BodyCollision() &&
                   !thisSnake.headCollisionFlag && thisSnake.headNoCollision(snake))
            {
                // Update sanke
                thisSnake.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            //spriteBatch.Draw(Resources.screen, Vector2.Zero, Color.White);
            
            // Draw food
            food.Draw(spriteBatch);

            //spriteBatch.DrawString(Resources.font, "Score", new Vector2(WIDTH / 2f, HEIGHT / 2f), Color.White);
            //spriteBatch.Draw(Resources.font, Vector2.Zero, new Rectangle(60 * 0, 70 * 0, 70, 60), Color.White);
            
            // Draw snake
            snake.Draw(spriteBatch);
            if (snake2 != null)
            {
                snake2.Draw(spriteBatch);
            }
            
        }
    }
}
