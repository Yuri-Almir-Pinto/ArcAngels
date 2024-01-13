using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Components.Object;
using System;

namespace ArcAngels.ArcAngels.Components.Moveable
{
    public class SelfMoveableComponent : AbstractComponent
    {
        private readonly Type[] _dependencies = new Type[2] { typeof(ObjectComponent), typeof(ControllableComponent) };
        public override Type[] Dependencies { get { return _dependencies; } }

        public float Speed;
    }
}
