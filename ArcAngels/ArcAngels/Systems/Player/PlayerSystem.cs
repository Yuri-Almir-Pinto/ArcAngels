using ArcAngels.ArcAngels.Components.Moveable;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Exceptions;
using ArcAngels.ArcAngels.Systems.Event;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems.Player
{
    public class PlayerSystem : AbstractSystem
    {
        private IEventSystem _eventSystem;
        private Entity _playerEntity;
        private static Type[] _dependencies = new Type[3]
        {
            typeof(ObjectComponent),
            typeof(DrawableComponent),
            typeof(SelfMoveableComponent)
        };

        private List<Keys> PressedKeys = new List<Keys>();
        private Rectangle pos = new Rectangle();

        public override Type[] Dependencies { get { return _dependencies; } }
        public PlayerSystem(IEventSystem eventSystem, Entity playerEntity) 
        {
            _eventSystem = eventSystem;
            
            if (!HasDependencies(playerEntity))
                throw new DependencyNotFound("Dependency not found while trying to instantiate 'PlayerSystem'. It must contain all: 'ObjectComponent', 'DrawableComponent', 'SelfMoveableComponent'.");

            _playerEntity = playerEntity;
            ObjectComponent component = (ObjectComponent) _playerEntity.Components.GetComponent(_dependencies[0]);
            pos = component.Rectangle;

            _eventSystem.AddEventListener(EventType.KeyPressed, PressedKeyHandler);
            _eventSystem.AddEventListener(EventType.KeyReleased, ReleasedKeyHandler);
            _eventSystem.AddEventListener(EventType.Update, MovePlayer);
        }

        public void PressedKeyHandler(object sender, SystemsArgs args)
        {

            if (args.InputArgs != null)
            {
                Keys keyPressed = args.InputArgs.PressedKey[0];

                if (!PressedKeys.Contains(keyPressed))
                {
                    PressedKeys.Add(keyPressed);
                }
            }
        }

        public void ReleasedKeyHandler(object sender, SystemsArgs args)
        {
            if (args.InputArgs != null)
            {
                Keys keyReleased = args.InputArgs.PressedKey[0];

                if (PressedKeys.Contains(keyReleased))
                {
                    PressedKeys.Remove(keyReleased);
                }
            }

        }

        public void MovePlayer(object sender, SystemsArgs args)
        {
            if (PressedKeys.Count > 0)
            {
                ObjectComponent objectComponent = (ObjectComponent) _playerEntity.Components.GetComponent(_dependencies[0]);
                SelfMoveableComponent selfMoveableComponent = (SelfMoveableComponent) _playerEntity.Components.GetComponent(_dependencies[2]);

                if (PressedKeys.Contains(Keys.A))
                    pos.X -= (int) selfMoveableComponent.Speed;

                if (PressedKeys.Contains(Keys.D))
                    pos.X += (int)selfMoveableComponent.Speed;

                objectComponent.Rectangle = pos;
            }
            
        }
    }
}
