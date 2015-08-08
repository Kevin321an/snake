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
        static Random generator = new Random();
        private Vector2 position;
        public Vector2 Position
        {
            get
            {
                return position;
            }
        }
        //generate the random position of food
        public Food()
        {
                       
            float x = generator.Next(GameManager.Width / GameManager.Tile_Size);
            float y = generator.Next(GameManager.Height / GameManager.Tile_Size);      
            position = new Vector2(x, y);
        }
        //shot it on the board
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.tile, position * GameManager.Tile_Size, Color.White);
        }
    }
}
