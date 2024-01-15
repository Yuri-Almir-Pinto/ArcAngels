using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Moveable;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Systems.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace ArcAngels.ArcAngels.Entities.Player
{
    public static class PlayerEntity
    {

        public static Entity Spawn(EntitySystem entitySystem, Texture2D texture)
        {
            Entity playerEntity = entitySystem.SpawnEntity<Entity>(new AbstractComponent[]
                {
                    new ObjectComponent { Rectangle = new Rectangle { X = 0, Y = 0, Height = 250, Width = 100 } },
                    new DrawableComponent { Texture =  texture},
                    new SelfMoveableComponent { Speed = 3}
                });

            return playerEntity;
        }
    }
}
