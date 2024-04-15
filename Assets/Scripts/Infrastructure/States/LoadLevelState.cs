using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IGameFactory _gameFactory;

        private Vector3 _initialPoint;
        private KeySpawner _keySpawner;

        public LoadLevelState(IGameStateMachine gameStateMachine,
            ISaveLoadService saveLoadService,
            IGameFactory gameFactory, 
            KeySpawner keySpawner)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
            _keySpawner = keySpawner;
        }

        public void Enter()
        {
            LevelLocation location = _gameFactory.CreateLevelLocation();
            _keySpawner.SpawnKeys(location.KeySpawnPositions);
            
            _gameFactory.CreatePlayer(location.PlayerSpawnPoint.position);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}