using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        private Snake snake;
        private int timeCount;
        private int score;

        public void Initialize()
        {
            snake = new Snake();
            food = new Food();
            timeCount = 0;
        }

        public void Update(GameTime gameTime)
        {
            // Add time elapsed since last frame to counter
            timeCount += gameTime.ElapsedGameTime.Milliseconds;
            
            // Update input controller
            InputController.Update();
            
            // Check if time passed is greater than the interval
            if(timeCount > INTERVAL)
            {
                
                //check collision of snake
                if (!snake.BodyCollision())
                {
                    // Update snake
                    snake.Update(gameTime);
                }                
                             
                

                // Check collision snake food
                bool flag=snake.Collision(food.Position.X, food.Position.Y, snake.Head);
                if(flag)
                {
                    snake.BodyGrow(); 
                    score += 1;
                    do
                    {
                        //food = null;

                        food = new Food();
                    } while (snake.Collision(food.Position.X, food.Position.Y, snake.Head));                                       
                                      

                }  
               
                
                    
                
                
                
                    


                // Clear input controller
                InputController.Clear();

                // Clear counter
                timeCount = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw background
            //spriteBatch.Draw(Resources.screen, Vector2.Zero, Color.White);
            
            // Draw food
            food.Draw(spriteBatch);

            //spriteBatch.DrawString(Resources.font, "Score", new Vector2(WIDTH / 2f, HEIGHT / 2f), Color.White);
            spriteBatch.Draw(Resources.font, Vector2.Zero, new Rectangle(60 * 0, 70 * 0, 70, 60), Color.White);
            
            // Draw snake
            snake.Draw(spriteBatch);
        }
    }
}
