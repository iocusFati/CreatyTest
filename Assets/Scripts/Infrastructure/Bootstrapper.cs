using System;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string GameSceneName = "GameScene";
        
        private IGameStateMachine _gameStateMachine;
        private StatesFactory _statesFactory;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine, StatesFactory statesFactory)
        {
            _gameStateMachine = gameStateMachine;
            _statesFactory = statesFactory;
        }

        private void Awake()
        {
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadLevelState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameLoopState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<GameLostState>());
            _gameStateMachine.RegisterState(_statesFactory.Create<LoadProgressState>());
            
            _gameStateMachine.Enter<LoadLevelState, string>(GameSceneName);
        }
    }
}