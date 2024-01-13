using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Components.MainPlayer;
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
        private EventSystem _eventSystem;
        private KeyboardState _previousKeyboardState;

        public InputSystem(EventSystem eventSystem) 
        {
            _eventSystem = eventSystem;
            _previousKeyboardState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState keyboardState = Keyboard.GetState();
            Keys[] pressedKeys = keyboardState.GetPressedKeys();
            Keys[] previousKeys = _previousKeyboardState.GetPressedKeys();
            
            if (!pressedKeys.SequenceEqual(previousKeys))
            {
                if (pressedKeys.Length > previousKeys.Length)
                {
                    Keys[] pressed = pressedKeys.Except(previousKeys).ToArray();

                    SystemsArgs keys = new SystemsArgs(new ControllableComponent
                    {
                        PressedKeys = pressed
                    });

                    _eventSystem.Call(EventType.KeyPressed, args: keys);

                    _previousKeyboardState = keyboardState;
                }
                else if (pressedKeys.Length < previousKeys.Length)
                {
                    Keys[] released = previousKeys.Except(pressedKeys).ToArray();

                    SystemsArgs keys = new SystemsArgs(new ControllableComponent
                    {
                        PressedKeys = released
                    });

                    _eventSystem.Call(EventType.KeyReleased, args: keys);

                    _previousKeyboardState = keyboardState;
                }
            }
        }

    }
}

namespace ArcAngels.ArcAngels.Systems.Event
{
    public partial class EventType
    {
        public static readonly EventType KeyPressed = new("KeyPressed");
        public static readonly EventType KeyReleased = new("KeyReleased");
    }
}



