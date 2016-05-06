using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Snake
{
    class SpecialFood:Food
        
    {      
        //shot the special food on the screen with different texture
        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Resources.SpeacialFood, Position * GameManager.Tile_Size, Color.White);
        }
    }
}
