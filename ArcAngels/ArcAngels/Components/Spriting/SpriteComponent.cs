using ArcAngels.ArcAngels.Components.Object;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Spriting
{
    // A component that stores data relevant to rendering an entity on the screen, such as sprites.
    public class SpriteComponent : AbstractComponent
    {
        public override List<AbstractComponent> Dependencies 
        { 
            get 
            {
                return new List<AbstractComponent>
                {
                    new ObjectComponent()
                }; 
            } 
        }
    }
}
