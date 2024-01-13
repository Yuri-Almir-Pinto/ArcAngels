using ArcAngels.ArcAngels.Entities;
using System;

namespace ArcAngels.ArcAngels.Systems.Event
{
    public interface IEventSystem
    {
        void Call(EventType type, Entity? entity = null, SystemsArgs? args = null);
        void AddEventListener(EventType type, EventHandler<EventArgs> handler);
        bool RemoveEventListener(EventType type, EventHandler<EventArgs> handler);
    }
}
