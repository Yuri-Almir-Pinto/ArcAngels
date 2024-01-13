using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Systems.Event;
using System;

namespace ArcAngels.ArcAngels.Components.MainPlayer
{
    public class MainPlayerComponent : AbstractComponent
    {
        private readonly Type[] _dependencies = new Type[1] { typeof(ControllableComponent) };
        public override Type[] Dependencies {  get { return _dependencies; } }
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