using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Systems.Event;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Diagnostics;
using System.Linq;

namespace ArcAngels.ArcAngels.Systems.Input
{
    public class InputSystem : AbstractSystem
    {
        //private readonly Type[] _dependencies = new Type[1] { typeof(MainPlayerComponent) };
        //public override Type[] Dependencies {  get { return _dependencies; } }
        private IEventSystem _eventSystem;
        private KeyboardState _previousKeyboardState;

        public InputSystem(IEventSystem eventSystem) 
        {
            _eventSystem = eventSystem;
            _previousKeyboardState = Keyboard.GetState();

            _eventSystem.AddEventListener(EventType.Update, Update);
        }

        public void Update(object sender = null, SystemsArgs args = null)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            Keys[] previousKeys = _previousKeyboardState.GetPressedKeys();

            // Check for newly pressed keys
            foreach (Keys key in pressedKeys)
            {
                if (!_previousKeyboardState.IsKeyDown(key))
                {
                    // Key was just pressed
                    SystemsArgs keyPressedArgs = new SystemsArgs
                    {
                        InputArgs = new InputArgs { PressedKey = new Keys[] { key } }
                    };

                    _eventSystem.Call(EventType.KeyPressed, args: keyPressedArgs);
                }
            }

            // Check for released keys
            foreach (Keys key in previousKeys)
            {
                if (!keyboardState.IsKeyDown(key))
                {
                    // Key was just released
                    SystemsArgs keyReleasedArgs = new SystemsArgs
                    {
                        InputArgs = new InputArgs { PressedKey = new Keys[] { key } }
                    };

                    _eventSystem.Call(EventType.KeyReleased, args: keyReleasedArgs);
                }
            }

            // Update the previous keyboard state
            _previousKeyboardState = keyboardState;
        }

        /*public void Update(object sender = null, SystemsArgs args = null)
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            Keys[] previousKeys = _previousKeyboardState.GetPressedKeys();

            if (!pressedKeys.SequenceEqual(previousKeys))
            {
                if (pressedKeys.Length > previousKeys.Length)
                {
                    Keys[] pressed = pressedKeys.Except(previousKeys).ToArray();

                    SystemsArgs keys = new SystemsArgs
                    {
                        InputArgs = new InputArgs { PressedKey = pressed }
                    };

                    _eventSystem.Call(EventType.KeyPressed, args: keys);

                    _previousKeyboardState = keyboardState;
                }
                else if (pressedKeys.Length < previousKeys.Length)
                {
                    Keys[] released = previousKeys.Except(pressedKeys).ToArray();

                    SystemsArgs keys = new SystemsArgs
                    {
                        InputArgs = new InputArgs { PressedKey = released }
                    };

                    _eventSystem.Call(EventType.KeyReleased, args: keys);

                    _previousKeyboardState = keyboardState;
                }
            }
        }*/

    }
}

namespace ArcAngels.ArcAngels.Systems.Event
{
    public partial class EventType
    {
        public static readonly EventType KeyPressed = new("KeyPressed");
        public static readonly EventType KeyReleased = new("KeyReleased");
    }

    public partial class SystemsArgs
    {
        public InputArgs InputArgs;
    }

    public class InputArgs : EventArgs
    {
        public Keys[] PressedKey;
    }
}



