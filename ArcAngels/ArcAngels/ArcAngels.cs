using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Entities.Player;
using ArcAngels.ArcAngels.Systems.Event;
using ArcAngels.ArcAngels.Systems.Input;
using ArcAngels.ArcAngels.Systems.Player;
using ArcAngels.ArcAngels.Systems.Rendering;
using ArcAngels.ArcAngels.Systems.World;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace ArcAngels.Main
{
    public class ArcAngels : Game
    {
        private GraphicsDeviceManager _graphics;
        private RenderingSystem _renderingSystem;
        private EventSystem _eventSystem;
        private EntitySystem _entitySystem;
        private InputSystem _inputSystem;
        private PlayerSystem _playerSystem;

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
            _inputSystem = new InputSystem(_eventSystem);
            Entity player = PlayerEntity.Spawn(_entitySystem, Content.Load<Texture2D>("Akioteste"));
            _playerSystem = new PlayerSystem(_eventSystem, player);

            base.Initialize();
        }

        protected override void LoadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            _eventSystem.Call(EventType.Update);
            

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _renderingSystem.Render(_entitySystem.GetEntityByComponent(_renderingSystem.Dependencies));

            base.Draw(gameTime);
        }

        public void Batata(object entity, SystemsArgs args)
        {
            if (args.InputArgs != null)
            {
                Debug.WriteLine(args.InputArgs.PressedKey[0]);
            }
        }

        public void Cenoura(object entity, SystemsArgs args)
        {
            if (args.InputArgs != null)
            {
                Debug.WriteLine(args.InputArgs.PressedKey[0]);
            }
        }
    }
}