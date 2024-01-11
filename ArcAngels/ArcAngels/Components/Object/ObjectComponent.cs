using Microsoft.Xna.Framework;

namespace ArcAngels.ArcAngels.Components.Object
{
    // A component that stores data about the location of an entity.
    public class ObjectComponent : AbstractComponent
    {
        public required Rectangle Rectangle { get; set; }
    }
}
