using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Cocos2D;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        GameManager gameManager;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = GameManager.HEIGHT;
            graphics.PreferredBackBufferWidth = GameManager.WIDTH;
            

            gameManager = new GameManager();
        }
       

        protected override void LoadContent()
        {
            
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            
            // Load resources
            Resources.Load(Content);
            
            // Initialize game
            gameManager.Initialize();
        }

        protected override void Update(GameTime gameTime)
        {
            gameManager.Update(gameTime);
            base.Update(gameTime);
            //reset the game
            if (InputController.IsReset)
            {
                Game1 game = new Game1();
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            graphics.GraphicsDevice.Clear(Color.White);
            spriteBatch.Begin();
            gameManager.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}