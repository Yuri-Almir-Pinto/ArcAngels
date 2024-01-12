using ArcAngels.ArcAngels.Components.Object;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Controllable
{
    public class ControllableComponent : AbstractComponent
    {
        public IEnumerable<Keys> PressedKeys;
    }
}
