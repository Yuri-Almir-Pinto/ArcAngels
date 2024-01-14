using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Controllable
{
    public class InputComponent : AbstractComponent
    {
        public IEnumerable<Keys> PressedKeys;
    }
}
