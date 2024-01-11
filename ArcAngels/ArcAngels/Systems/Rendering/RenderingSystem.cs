using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ArcAngels.ArcAngels.Systems.Rendering
{
    public class RenderingSystem : AbstractSystem
    {
        private SpriteBatch _spriteBatch;
        public override Type[] Dependencies {  get
            {
                return new Type[1]
                {
                    typeof(SpriteComponent)
                };
            } 
        }

        public RenderingSystem(SpriteBatch spriteBatch)
        {
            _spriteBatch = spriteBatch;
        }

        public void Render(IEnumerable<Entity> entities)
        {
            _spriteBatch.Begin();

            foreach (var entity in entities)
            {
                ObjectComponent objectComponent = (ObjectComponent) entity.Components.GetComponent(typeof(ObjectComponent));
                SpriteComponent spriteComponent = (SpriteComponent) entity.Components.GetComponent(typeof(SpriteComponent));

                _spriteBatch.Draw(spriteComponent.Texture, 
                    new Vector2 { X = objectComponent.XPosition, Y = objectComponent.YPosition },
                    Color.White);
            }

            _spriteBatch.End();
        }
    }
}
