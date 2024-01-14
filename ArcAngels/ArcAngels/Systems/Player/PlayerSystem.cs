using ArcAngels.ArcAngels.Entities;
using ArcAngels.ArcAngels.Entities.Player;
using ArcAngels.ArcAngels.Systems.Event;

namespace ArcAngels.ArcAngels.Systems.Player
{
    public class PlayerSystem
    {
        private IEventSystem _eventSystem;
        private PlayerEntity _playerEntity;
        public PlayerSystem(IEventSystem eventSystem, PlayerEntity playerEntity) 
        {
            _eventSystem = eventSystem;
            _playerEntity = playerEntity;
        }
    }
}
