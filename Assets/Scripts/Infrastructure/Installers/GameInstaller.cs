using Gameplay.Level;
using Infrastructure.States;
using Zenject;

namespace Infrastructure
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            BindStatesFactory();
            BindStateMachine();
            BindKeySpawner();
            BindGameStarter();
        }

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