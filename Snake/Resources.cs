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
        public static Texture2D font;
        public static Texture2D player2;
        public static void Load(ContentManager content)
        {
            screen = content.Load<Texture2D>("Textures/screen");
            tile = content.Load<Texture2D>("Textures/tile");
            tail2 = content.Load<Texture2D>("Textures/tail2");
            font = content.Load<Texture2D>("fonts/font");
            player2 = content.Load<Texture2D>("Textures/palyer2");

        }
    }
}
