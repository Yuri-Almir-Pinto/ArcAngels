
using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using System.Collections.Generic;

namespace ArcAngels.Main
{
    class Entry
    {
        public static int Main()
        {
            var game = new ArcAngels();
            // game.Run();

            Entity entity = new Entity(new List<AbstractComponent> { new SpriteComponent() });

            Entity newEntity = new Entity(new List<AbstractComponent> { new SpriteComponent() });

            bool contains = entity.Components.ComponentIsPresent(new ObjectComponent());

            var aids = "aids";

            return 0;
        }
        
    }
    
}


