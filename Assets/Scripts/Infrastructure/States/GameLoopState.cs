using Gameplay.Level;
using UniRx;
using UnityEngine;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IKeysHolder _keysHolder;
        
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
            Debug.Log("Door opened!");
        }

        public void Exit()
        {
            
        }
    }
}