using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure.Services.SaveLoad;
using UnityEngine;

namespace Infrastructure.States
{
    public class LoadLevelState : IState
    {
        private readonly ISaveLoadService _saveLoadService;
        private readonly IStateMachine _stateMachine;
        private readonly IGameFactory _gameFactory;
        private readonly LevelLocation _location;
        private readonly KeySpawner _keySpawner;

        private Vector3 _initialPoint;

        public LoadLevelState(IStateMachine stateMachine,
            ISaveLoadService saveLoadService,
            IGameFactory gameFactory, 
            KeySpawner keySpawner, 
            LevelLocation location)
        {
            _stateMachine = stateMachine;
            _saveLoadService = saveLoadService;
            _gameFactory = gameFactory;
            _keySpawner = keySpawner;
            _location = location;
        }

        public void Enter()
        {
            _keySpawner.SpawnKeys(_location.KeySpawnPositions);
            
            _gameFactory.CreatePlayer(_location.PlayerSpawnPoint.position);
            
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}