using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Food
    {
        public Vector2 position;

        public Vector2 Position
        {
            get
            {
                return position;
            }
        }

        public Food()
        {
            Random generator = new Random();
            
            float x = generator.Next(GameManager.WIDTH / GameManager.TILE_SIZE);
            float y = generator.Next(GameManager.HEIGHT / GameManager.TILE_SIZE);

           
            
            
            
            
            position = new Vector2(x, y);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.tile, position * GameManager.TILE_SIZE, Color.White);
        }
    }
}
