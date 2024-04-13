using Infrastructure.Services.Input;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class GameLostState : IState
    {
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IInputService _inputService;
        private ICoroutineRunner _coroutineRunner;
        
        private readonly float _timeBeforeLose;
        private readonly float _cameraRotateDuration;
        
        public GameLostState(
            IGameStateMachine gameStateMachine)
            // IInputService inputService,
            // ICoroutineRunner coroutineRunner)
        {
            _gameStateMachine = gameStateMachine;
            // _inputService = inputService;
            // _coroutineRunner = coroutineRunner;
            
            Debug.Log("GameLost");
        }

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine)
        {

            Debug.Log("GameLost");
        }

        public void Enter()
        {
        }

        public void Exit()
        {
        }
        
        private void RestartGame()
        {
            _gameStateMachine.Enter<LoadLevelState, string>(SceneManager.GetActiveScene().name);
        }
    }
}