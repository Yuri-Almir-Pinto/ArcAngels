using ArcAngels.ArcAngels.Components.Controllable;
using ArcAngels.ArcAngels.Components.Object;
using System;

namespace ArcAngels.ArcAngels.Components.Moveable
{
    public class SelfMoveableComponent : AbstractComponent
    {
        public override Type[] Dependencies
        {
            get
            {
                return new Type[2]
                {
                    typeof(ObjectComponent),
                    typeof(ControllableComponent)
                };
            }
        }

        public float Speed;
    }
}
