using ArcAngels.ArcAngels.Systems.Event;
using ArcAngels.ArcAngels.Systems.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArcAngels.ArcAngels.Systems.World
{
    public class WorldSystem : AbstractSystem
    {
        private RenderingSystem _renderingSystem;
        private EventSystem _eventSystem;
        private EntitySystem _entitySystem;
        private ContentManager _content;
        public WorldSystem(SpriteBatch spriteBatch, ContentManager content) 
        {
            this._renderingSystem = new RenderingSystem(spriteBatch);
            this._eventSystem = new EventSystem();
            this._entitySystem = new EntitySystem();
            this._content = content;
        }

        public void Draw()
        {
            // _renderingSystem.Render(_entitySystem.RenderableEntities);
        }
    }
}
