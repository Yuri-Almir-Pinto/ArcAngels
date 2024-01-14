using ArcAngels.ArcAngels.Components;
using ArcAngels.ArcAngels.Components.Moveable;
using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace ArcAngels.ArcAngels.Entities.Player
{
    public class PlayerEntity : Entity
    {
        public PlayerEntity(Texture2D texture, int X = 0, int Y = 0, int height = 300, int width = 100, float speed = 1) 
            : base(Init(texture, X, Y, height, width, speed))
        {
            
        }

        private static AbstractComponent[] Init(Texture2D texture, int X, int Y, int height, int width, float speed)
        {
            return new AbstractComponent[]
            {
                new ObjectComponent { Rectangle = new Rectangle { X = X, Y = Y, Height = height, Width = width } },
                new DrawableComponent { Texture = texture },
                new SelfMoveableComponent { Speed = speed}
            };

        }
    }
}
