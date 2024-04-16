using Base.UI.Factory;
using Gameplay.Level;
using Gameplay.Level.Location;
using Gameplay.Level.Plot;
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
            BindTimer();
            BindLevelPlot();

            BindGameStarter();
        }
        
        private void BindTimer()
        {
            Container
                .Bind<Timer>()
                .FromNew()
                .AsSingle();
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
            Container.ParentContainers[0]
                .Bind<IStateMachine>()
                .To<StateMachine>()
                .AsSingle();
        }
    }
}