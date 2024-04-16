using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure.States;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        [SerializeField] private LevelLocation _location;
        [SerializeField] private CameraStates _cameraStates;

        public override void InstallBindings()
        {
            BindLocation();
            
            BindStatesFactory();
            BindStateMachine();

            BindKeySpawner();
            BindCameraStates();
            BindLevelPlot();
            
            BindGameStarter();
        }

        private void BindLocation()
        {
            Container
                .Bind<LevelLocation>()
                .FromInstance(_location)
                .AsSingle();
        }

        private void BindCameraStates() =>
            Container
                .Bind<CameraStates>()
                .FromInstance(_cameraStates)
                .AsSingle();

        private void BindLevelPlot() =>
            Container
                .Bind<LevelPlot>()
                .FromNew()
                .AsSingle();

        private void BindStatesFactory()
        {
            Container
                .Bind<StatesFactory>()
                .FromNew()
                .AsSingle();
        }

        private void BindGameStarter()
        {
            Container
                .BindInterfacesTo<GameStarter>()
                .FromNew()
                .AsSingle();
        }

        private void BindKeySpawner()
        {
            Container
                .BindInterfacesAndSelfTo<KeySpawner>()
                .FromNew()
                .AsSingle();
        }

        private void BindStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .AsSingle();
        }
    }
}