using ArcAngels.ArcAngels.Entities;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems.Event
{
    public class EventSystem
    {
        private Dictionary<EventType, EventHandler<EventArgs>> _eventListeners = new Dictionary<EventType, EventHandler<EventArgs>>();

        public void Call(Entity entity, EventType type)
        {
            if (_eventListeners.ContainsKey(type))
            {
                _eventListeners[type]?.Invoke(entity, EventArgs.Empty);
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

    public partial class EventType
    {
        public static readonly EventType Event = new("Event");
        public static readonly EventType Event2 = new("Event2");

        public string Type;

        public EventType(string eventType)
        {
            Type = eventType;
        }

    }
}
