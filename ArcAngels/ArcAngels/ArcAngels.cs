using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Systems.Event;
using ArcAngels.ArcAngels.Systems.Rendering;
using ArcAngels.ArcAngels.Systems.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcAngels.Main
{
    public class ArcAngels : Game
    {
        private GraphicsDeviceManager _graphics;
        private RenderingSystem _renderingSystem;
        private EventSystem _eventSystem;
        private EntitySystem _entitySystem;

        public ArcAngels()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _renderingSystem = new RenderingSystem(new SpriteBatch(GraphicsDevice));
            _eventSystem = new EventSystem();
            _entitySystem = new EntitySystem();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Entity entity = _entitySystem.SpawnEntity<Entity>(
                new ObjectComponent { Rectangle = new Rectangle { X = 0, Y = 0, Height = 100, Width = 50 } },
                new DrawableComponent { Texture = Content.Load<Texture2D>("Akioteste") }
            );
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //_renderingSystem.Render(_entitySystem.RenderableEntities);

            base.Draw(gameTime);
        }
    }
}