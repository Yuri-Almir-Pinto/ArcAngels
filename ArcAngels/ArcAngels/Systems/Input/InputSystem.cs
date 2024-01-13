using ArcAngels.ArcAngels.Components.MainPlayer;
using System;

namespace ArcAngels.ArcAngels.Systems.Input
{
    public class InputSystem : AbstractSystem
    {
        private readonly Type[] _dependencies = new Type[1] { typeof(MainPlayerComponent) };
        public override Type[] Dependencies {  get { return _dependencies; } }

        public void Update()
        {

        }
    }
}
