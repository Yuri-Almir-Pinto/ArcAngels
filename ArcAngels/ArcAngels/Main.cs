
using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using System.Collections.Generic;

namespace ArcAngels.Main
{
    class Entry
    {
        public static void Main()
        {
            var game = new ArcAngels();
            // game.Run();

            Entity entity = new Entity(new List<AbstractComponent> { new SpriteComponent() });
            Entity entity2 = new Entity(new List<AbstractComponent> { new SpriteComponent() });
            Entity entity3 = new Entity(new List<AbstractComponent> { new SpriteComponent() });
            Entity entity4 = new Entity(new List<AbstractComponent> { new SpriteComponent() });
            Entity entity5 = new Entity(new List<AbstractComponent> { new SpriteComponent() });

            entity3.RemoveEntity();
            entity4.RemoveEntity();
            entity2.RemoveEntity();

            Entity newEntity = new Entity(new List<AbstractComponent> { new SpriteComponent() });

            bool contains = entity.Components.ComponentExists(new ObjectComponent());

            var aids = "aids";
        }
        
    }
    
}


