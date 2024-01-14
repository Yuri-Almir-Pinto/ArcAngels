using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Components.Object;
using System;

namespace ArcAngels.ArcAngels.Components.Moveable
{
    public class SelfMoveableComponent : AbstractComponent
    {
        private readonly Type[] _dependencies = new Type[1] { typeof(ObjectComponent) };
        public override Type[] Dependencies { get { return _dependencies; } }

        public required float Speed;
    }
}
