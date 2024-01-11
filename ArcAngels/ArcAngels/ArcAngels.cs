using ArcAngels.ArcAngels.Components.Object;
using ArcAngels.ArcAngels.Components.Spriting;
using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Systems;
using ArcAngels.ArcAngels.Systems.Rendering;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace ArcAngels.Main
{
    public class ArcAngels : Game
    {
        private GraphicsDeviceManager _graphics;
        public WorldSystem World;
        public RenderingSystem RenderingSystem;

        public ArcAngels()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            World = new WorldSystem();
            RenderingSystem = new RenderingSystem(new SpriteBatch(GraphicsDevice));

            base.Initialize();
        }

        protected override void LoadContent()
        {
            World.SpawnEntity(typeof(Entity),
                new ObjectComponent { XPosition = 0, YPosition = 0},
                new SpriteComponent { Texture = Content.Load<Texture2D>("Akioteste") });
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

            RenderingSystem.Render(World.RenderableEntities);

            base.Draw(gameTime);
        }
    }
}