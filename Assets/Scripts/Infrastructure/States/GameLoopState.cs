using Gameplay.Level;
using Gameplay.Level.Location;
using UniRx;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IKeysHolder _keysHolder;
        private LevelLocation _location;

        public GameLoopState(IKeysHolder keysHolder)
        {
            _keysHolder = keysHolder;
        }

        public void Enter()
        {
            _keysHolder.UncollectedKeysCount
                .Where(currentCount => currentCount == 0)
                .Subscribe(_ => OpenDoor());
        }

        private void OpenDoor()
        {
            _location.OpenDoor();
        }

        public void Exit()
        {
            
        }
    }
}