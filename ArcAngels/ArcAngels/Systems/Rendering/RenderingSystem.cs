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
        private readonly Type[] _dependencies = new Type[1] { typeof(DrawableComponent) };
        public override Type[] Dependencies { get { return _dependencies; } }

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
                DrawableComponent spriteComponent = (DrawableComponent) entity.Components.GetComponent(typeof(DrawableComponent));

                _spriteBatch.Draw(spriteComponent.Texture, 
                    objectComponent.Rectangle,
                    Color.White);
            }

            _spriteBatch.End();
        }
    }
}
