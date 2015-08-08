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
        
        //Alternative Resolution: 1280*736 or 1600*896
        private static readonly int HEIGHT = 896;
        static public int Height
        {
            get
            {
                return HEIGHT;
            }
        }
        private static readonly int WIDTH = 1600;
        static public int Width
        {
            get
            {
                return WIDTH;
            }
        }
        private static readonly int TILE_SIZE = 32;
        static public int Tile_Size
        {
            get
            {
                return TILE_SIZE;
            }
        }
        //Game Speed
        private static  int INTERVAL = 300;
        //Special food will apear after how many normal food
        private static readonly int SEPCIAL_FOOD_INTERVAR = 5;
        private int foodCount;
        private Food food;
        private SpecialFood specialFood;
        private Snake snake, snake2;
        private InputController inputControllerP1,inputControllerP2;
        private int timeCount;
        private int score;
        //Snake number counter
        private int numberOfSnake = 0;
        private bool hasSnake2;
        private GameTime gameTime;

        //initial the game
        public void Initialize()
        {
            inputControllerP1 = new InputController(Keys.A, Keys.D, Keys.W, Keys.S);
            inputControllerP2 = new InputController(Keys.Left, Keys.Right, Keys.Up, Keys.Down);
            snake = new Snake(inputControllerP1,Resources.tail2);            
            food = new Food();
            foodCount = 0;
            timeCount = 0;
        }
        //main segment when game is running 
        public void Update(GameTime gameTime)
        {
            this.gameTime = gameTime;
            // Add time elapsed since last frame to counter
            timeCount += gameTime.ElapsedGameTime.Milliseconds;
            
            // Update input controller
            snake.InputController.Update();
            if (hasSnake2)
            {                
                snake2.InputController.Update();
            }

            //add specialFood
            if (foodCount > SEPCIAL_FOOD_INTERVAR)
            {                
                do
                {                    
                    specialFood = new SpecialFood();
                } while (snake.Collision(food.Position.X, food.Position.Y, snake.Head));
                foodCount=foodCount - SEPCIAL_FOOD_INTERVAR;
            }
            //reset the game
            if (InputController.IsReset)
            {
                snake.InputController.Clear();
                Initialize();                
                if (hasSnake2)
                {
                    snake2.InputController.Clear();
                    snake2 = null;
                    hasSnake2 = false;
                    numberOfSnake = 0;
                }
            }

            //add second snake when press insert key           
            if (InputController.IsInsertPressed && numberOfSnake == 0)
            {
                numberOfSnake++;
                snake2 = new Snake(inputControllerP2, Resources.player2);
                hasSnake2 = true;
            }

            //increse speed
            if (InputController.IsIncrease)
            {
                INTERVAL+=100;                
            }

            // Check if time passed is greater than the interval
            if (timeCount > INTERVAL)
            {                
                //check collision of snake                
                    if (hasSnake2)
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
               
                if (hasSnake2)
                {
                    updateSnake(snake2, snake);
                }

                // Check collision snake food
                foodCollision(snake);
                SpecialfoodCollision(snake);
                if (hasSnake2)
                {
                    foodCollision(snake2);
                    SpecialfoodCollision(snake2);
                }
               
                // Clear input controller
                snake.InputController.Clear();
                if (hasSnake2)
                {
                    snake2.InputController.Clear();
                }

                // Clear counter
                timeCount = 0;
            }
        }
        //when snake eat food and generate a new one
        public void foodCollision(Snake snake)
        {            
            bool flag = snake.Collision(food.Position.X, food.Position.Y, snake.Head);
            if (flag)
            {
                snake.BodyGrow();
                score += 1;
                
                foodCount++;
                do
                {                   
                    food = new Food();
                    
                } while (snake.Collision(food.Position.X, food.Position.Y, snake.Head));
            }
        }

        //snake eat specialFood
        public void SpecialfoodCollision(Snake snake)
        {            
            if (specialFood!=null&&snake.Collision(specialFood.Position.X, specialFood.Position.Y, snake.Head))
            {
                snake.BodyGrow();
                snake.BodyGrow();
                score += 2;
                specialFood = null;
            }
        }

        //update the snake motion while it alive
        public void updateSnake(Snake thisSnake, Snake anotherSnake)
        {
            //check if the sanke crash the body of itsself
            //then check if the sanke has ever been crashed 
            //last, check if the snake is crashing with another snake's body 
            if (!thisSnake.BodyCollision() &&
                   !thisSnake.headCollisionFlag && 
                   thisSnake.headNoCollision(anotherSnake))
            {
                // Update sanke
                thisSnake.Update(gameTime);
            }
        }

        //shot GUI on the board
        public void Draw(SpriteBatch spriteBatch)
        {    
            // Draw food
            food.Draw(spriteBatch);
            if (specialFood != null)
            {
                specialFood.Draw(spriteBatch);
            }
       
            // Draw snake
            snake.Draw(spriteBatch);
            if (hasSnake2)
            {
                snake2.Draw(spriteBatch);
            }
            
        }
    }
}
