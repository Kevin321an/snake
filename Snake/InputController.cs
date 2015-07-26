using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake
{
    public class InputController
    {
        private bool isLeftPressed;
        private bool isRightPressed;
        private bool isUpPressed;
        private bool isDownPressed;
        private static bool isInsert;
        private static bool isReset;

        private Keys keyLeft;
        private Keys keyRight;
        private Keys keyUp;
        private Keys keyDown;
        private Keys insert;
        private Keys reset;

        public bool IsleftPressed
        {
            get
            {
                return isLeftPressed;
            }
        }

        public bool IsRightPressed
        {
            get
            {
                return isRightPressed;
            }
        }

        public bool IsUpPressed
        {
            get
            {
                return isUpPressed;
            }
        }

        public bool IsDownPressed
        {
            get
            {
                return isDownPressed;
            }
        }

        public static bool IsInsertPressed
        {
            get
            {
                return isInsert;
            }
        }
        public static bool IsReset
        {
            get
            {
                return isReset;
            }
        }

        public InputController(Keys keyLeft, Keys keyRight, Keys keyUp, Keys keyDown)
        {
            this.keyLeft = keyLeft;
            this.keyRight = keyRight;
            this.keyUp = keyUp;
            this.keyDown = keyDown;
            this.insert = Keys.Insert;
            this.reset = Keys.F5;
        }

        public void Update()
        {
            // Get keyboard state
            KeyboardState keyState = Keyboard.GetState();

            // Update directions pressed
            if (keyState.IsKeyDown(keyLeft))
            {
                isLeftPressed = true;
            }
            if (keyState.IsKeyDown(keyRight))
            {
                isRightPressed = true;
            }
            if (keyState.IsKeyDown(keyUp))
            {
                isUpPressed = true;
            }
            if (keyState.IsKeyDown(keyDown))
            {
                isDownPressed = true;
            }
            if (keyState.IsKeyDown(insert))
            {
                isInsert = true;
            }
            if (keyState.IsKeyDown(reset))
            {
                isReset = true;
            }
        }

        public void Clear()
        {
            // Clear all directions pressed
            isLeftPressed = false;
            isRightPressed = false;
            isUpPressed = false;
            isDownPressed = false;
            isReset = false;
            
            //isInsert = false;
        }
    }
}
