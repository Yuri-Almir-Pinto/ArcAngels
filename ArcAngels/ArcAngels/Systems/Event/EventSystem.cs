using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.Main;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems.Event
{

    public class EventSystem
    {
        private Dictionary<EventType, EventHandler<EventArgs>> _eventListeners = new Dictionary<EventType, EventHandler<EventArgs>>();

        public void Call(EventType type, Entity? entity = null, SystemsArgs? args = null)
        {
            if (_eventListeners.ContainsKey(type))
            {
                _eventListeners[type]?.Invoke(entity, args);
            }
        }

        public void addEventListener(EventType type, EventHandler<EventArgs> handler)
        {
            if (handler != null)
            {
                if(!_eventListeners.ContainsKey(type))
                {
                    _eventListeners.Add(type, handler);
                }
                else
                {
                    _eventListeners[type] += handler;
                }
            }
            else
            {
                throw new ArgumentNullException("Provided event handler is null.");
            }
        }

        public bool removeEventListener(EventType type, EventHandler<EventArgs> handler)
        {
            if (handler != null)
            {
                if( _eventListeners.ContainsKey(type))
                {
                    var previous = _eventListeners[type];
                    _eventListeners[type] -= handler;

                    if (previous == _eventListeners[type]) return false;
                    else return true;
                }
                else return false;
            }
            else
            {
                throw new ArgumentNullException("Provided event handler is null.");
            }
        }

    }
}
