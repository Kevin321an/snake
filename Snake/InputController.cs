using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public static class InputController
    {
        private static bool isLeftPressed;
        private static bool isRightPressed;
        private static bool isUpPressed;
        private static bool isDownPressed;

        public static bool IsleftPressed
        {
            get
            {
                return isLeftPressed;
            }
        }

        public static bool IsRightPressed
        {
            get
            {
                return isRightPressed;
            }
        }

        public static bool IsUpPressed
        {
            get
            {
                return isUpPressed;
            }
        }

        public static bool IsDownPressed
        {
            get
            {
                return isDownPressed;
            }
        }

        public static void Update()
        {
            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Update directions pressed
            if (keyState.IsKeyDown(Keys.A))
            {
                isLeftPressed = true;
            }
            if (keyState.IsKeyDown(Keys.D))
            {
                isRightPressed = true;
            }
            if (keyState.IsKeyDown(Keys.W))
            {
                isUpPressed = true;
            }
            if (keyState.IsKeyDown(Keys.S))
            {
                isDownPressed = true;
            }
        }

        public static void Clear()
        {
            // Clear all directions pressed
            isLeftPressed = false;
            isRightPressed = false;
            isUpPressed = false;
            isDownPressed = false;
        }
    }
}
