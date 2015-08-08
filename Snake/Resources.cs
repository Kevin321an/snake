using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    class Resources
    {
        public static Texture2D screen;
        public static Texture2D tile;
        public static Texture2D tail2;
        //public static Texture2D font;
        public static Texture2D player2;
        public static Texture2D specialfood;
        public static Texture2D Screen
        {
            get
            {
                return screen;
            }
            
        }
        public static Texture2D Tile
        {
            get
            {
                return tile;
            }

        }
        public static Texture2D Tail2
        {
            get
            {
                return tail2;
            }

        }
        public static Texture2D Player2
        {
            get
            {
                return player2;
            }

        }
        public static Texture2D SpeacialFood
        {
            get
            {
                return specialfood;
            }

        }
        //register the texture 
        public static void Load(ContentManager content)
        {
            screen = content.Load<Texture2D>("Textures/screen");
            tile = content.Load<Texture2D>("Textures/tile");
            tail2 = content.Load<Texture2D>("Textures/tail2");
            //font = content.Load<Texture2D>("fonts/CourierNew");
            player2 = content.Load<Texture2D>("Textures/palyer2");
            specialfood = content.Load<Texture2D>("Textures/specialfood");

        }
    }
}
