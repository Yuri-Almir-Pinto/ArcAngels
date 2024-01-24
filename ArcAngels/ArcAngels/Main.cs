using Microsoft.Xna.Framework;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Systems.World;
using System;
using System.Collections.Generic;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Components.Controllable;
using ECS_Library.Components;
namespace ArcAngels.Main
{
    class Entry
    {
        public static int Main()
        {
            var game = new ArcAngels();
            game.Run();

            /*entities.SpawnEntity<Entity>(
                    new ObjectComponent { Rectangle = new Rectangle { X = 0, Y = 0, Width = 100, Height = 300 } },
                    new ControllableComponent(),
                    new SelfMoveableComponent()
                );

            entities.SpawnEntity<Entity>(
                    new ObjectComponent { Rectangle = new Rectangle { X = 0, Y = 0, Width = 100, Height = 300 } },
                    new ControllableComponent()
                );
            entities.SpawnEntity<Entity>(
                    new ObjectComponent { Rectangle = new Rectangle { X = 0, Y = 0, Width = 100, Height = 300 } }
                );*/

            /*WorldSystem World = new WorldSystem();

            Entity entity1 = World.SpawnEntity(typeof(Entity));
            Entity entity2 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent(),
                new SpriteComponent());
            Entity entity3 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent());

            World.DespawnEntity(entity2);

            Entity entity4 = World.SpawnEntity(typeof(Entity),
                new ObjectComponent(),
                new SpriteComponent());*/

            return 0;
        }

        public static void Batata(object entity, EventArgs args)
        {
            Console.WriteLine("Batata.");
        }
        
    }
    
}


