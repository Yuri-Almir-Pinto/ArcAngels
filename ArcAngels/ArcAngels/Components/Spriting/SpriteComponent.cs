using ArcAngels.ArcAngels.Components.Object;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Components.Spriting
{
    public class SpriteComponent : AbstractComponent
    {
        public override string Name
        {
            get { return "Sprite"; }
        }

        public override List<AbstractComponent> GetDependencies()
        {
            return new List<AbstractComponent> { new ObjectComponent() };
        }
    }
}
