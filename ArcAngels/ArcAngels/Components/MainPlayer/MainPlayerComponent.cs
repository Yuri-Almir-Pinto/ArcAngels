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