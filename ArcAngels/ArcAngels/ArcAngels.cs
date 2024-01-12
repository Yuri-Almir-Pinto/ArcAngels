using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
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
        public EntitySystem EntitySystem;
        public RenderingSystem RenderingSystem;

        public ArcAngels()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            EntitySystem = new EntitySystem();
            RenderingSystem = new RenderingSystem(new SpriteBatch(GraphicsDevice));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Entity entity = EntitySystem.SpawnEntity<Entity>(
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

            RenderingSystem.Render(EntitySystem.RenderableEntities);

            base.Draw(gameTime);
        }
    }
}