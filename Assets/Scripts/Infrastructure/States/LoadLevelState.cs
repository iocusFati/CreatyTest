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
        private readonly LevelLocation _location;
        private readonly KeySpawner _keySpawner;

        private Vector3 _initialPoint;

        public LoadLevelState(IGameStateMachine gameStateMachine,
            ISaveLoadService saveLoadService,
            IGameFactory gameFactory, 
            KeySpawner keySpawner, 
            LevelLocation location)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
            _keySpawner = keySpawner;
            _location = location;
        }

        public void Enter()
        {
            _keySpawner.SpawnKeys(_location.KeySpawnPositions);
            
            _gameFactory.CreatePlayer(_location.PlayerSpawnPoint.position);
            
            _gameStateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}