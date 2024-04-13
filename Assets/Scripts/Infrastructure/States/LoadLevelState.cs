using Infrastructure.Services.SaveLoad;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace Infrastructure.States
{
    public class LoadLevelState : IPayloadedState<string>
    {
        private const string PlayerSpawnTag = "PlayerSpawn";
        
        private readonly ISaveLoadService _saveLoadService;
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPlayerFactory _playerFactory;
        private readonly SceneLoader _sceneLoader;

        private Vector3 _initialPoint;

        public LoadLevelState(IGameStateMachine gameStateMachine,
            ISaveLoadService saveLoadService,
            IPlayerFactory playerFactory, 
            SceneLoader sceneLoader)
        {
            _gameStateMachine = gameStateMachine;
            _saveLoadService = saveLoadService;
            _playerFactory = playerFactory;
            _sceneLoader = sceneLoader;
            
        }

        public void Enter(string sceneName)
        {
            if (sceneName != SceneManager.GetActiveScene().name)
            {
                _sceneLoader.Load(sceneName, OnLoaded);
            }
            else
            {
                Reload();
            }
        }

        public void Exit()
        {
            
        }

        private void OnLoaded()
        {
            _initialPoint = GameObject.FindWithTag(PlayerSpawnTag).transform.position;
            _playerFactory.CreatePlayer(_initialPoint);
            
            _saveLoadService.InformReaders();
            _gameStateMachine.Enter<GameLoopState>();
        }

        private void Reload()
        {
        }
    }
}