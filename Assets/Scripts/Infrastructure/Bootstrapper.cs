using System;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class Bootstrapper : MonoBehaviour
    {
        private const string GameSceneName = "GameScene";

        private SceneLoader _sceneLoader;
        private IUIMediator _uiMediator;

        [Inject]
        public void Construct(SceneLoader sceneLoader, IUIMediator uiMediator)
        {
            _sceneLoader = sceneLoader;
            _uiMediator = uiMediator;
        }

        private void Awake()
        {
            _uiMediator.InitializeForAllGame();
            _sceneLoader.Load(GameSceneName);
        }
    }
}