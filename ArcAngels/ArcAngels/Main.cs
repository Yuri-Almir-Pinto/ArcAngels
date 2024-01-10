
using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Systems;
using System.Collections.Generic;

namespace ArcAngels.Main
{
    class Entry
    {
        public static int Main()
        {
            var game = new ArcAngels();
            // game.Run();

            WorldSystem World = new WorldSystem();

            Entity entity1 = World.SpawnEntity(typeof(Entity));
            Entity entity2 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent(),
                new SpriteComponent());
            Entity entity3 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent());

            World.DespawnEntity(entity2);

            Entity entity4 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent(),
                new SpriteComponent());

            var aids = "aids";

            return 0;
        }
        
    }
    
}


