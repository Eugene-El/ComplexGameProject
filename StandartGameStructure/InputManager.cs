using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StandartGameStructure
{
    public class InputManager
    {
        private KeyboardState curreentKeyState, prevKeyState;

        public MouseState CurrentMouseState { get; private set; }
        public MouseState PrevMouseState { get; private set; }

        // Singleton 

        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new InputManager();
                return instance;
            }
        }

        private InputManager()
        {
            Update();
        }

        //

        public void Update()
        {
            prevKeyState = curreentKeyState;
            curreentKeyState = Keyboard.GetState();
            PrevMouseState = CurrentMouseState;
            CurrentMouseState = Mouse.GetState();
        }

        public bool KeyPressed(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (curreentKeyState.IsKeyDown(key) && prevKeyState.IsKeyUp(key))
                    return true;
            }

            return false;
        }

        public bool KeyReleased(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (curreentKeyState.IsKeyUp(key) && prevKeyState.IsKeyDown(key))
                    return true;
            }

            return false;
        }

        public bool KeyDown(params Keys[] keys)
        {
            foreach (Keys key in keys)
            {
                if (curreentKeyState.IsKeyDown(key))
                    return true;
            }

            return false;
        }
    }
}
