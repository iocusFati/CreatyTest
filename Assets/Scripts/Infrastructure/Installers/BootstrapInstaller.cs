using Base.UI.Factory;
using Infrastructure.AssetProviderService;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticDataService;
using Infrastructure.States;
using Infrastructure.Update;
using UnityEngine;
using Zenject;

namespace Infrastructure
{
    public class BootstrapInstaller : MonoInstaller, ICoroutineRunner
    {
        public override void InstallBindings()
        {
            BindStaticDataService();    
            BindUpdater();
            BindInputService();
            BindSceneLoader();
            BindCoroutineRunner();
            BindSaveLoadService();
            BindPersistentProgress();
            BindAssetsService();
            BindFactories();
            BindUIMediator();
        }

        private void BindUIMediator()
        {
            Container
                .Bind<IUIMediator>()
                .To<UIMediator>()
                .AsSingle();
        }

        private void BindStaticDataService()
        {
            Container
                .Bind<IStaticDataService>()
                .To<StaticDataService>()
                .AsSingle();
        }

        private void BindUpdater()
        {
            IUpdater updater = new GameObject("Updater").AddComponent<Updater>();
            
            Container
                .Bind<IUpdater>()
                .FromInstance(updater)
                .AsSingle();
        }

        private void BindInputService()
        {
            Container
                .Bind<IInputService>()
                .To<InputService>()
                .AsSingle();
        }

        private void BindAssetsService()
        {
            Container
                .Bind<IAssets>()
                .To<AssetProvider>()
                .AsSingle();
        }

        private void BindPersistentProgress()
        {
            Container
                .Bind<IPersistentProgressService>()
                .To<PersistentProgressService>()
                .AsSingle();
        }

        private void BindSaveLoadService()
        {
            Container
                .Bind<ISaveLoadService>()
                .To<SaveLoadService>()
                .AsSingle();
        }

        private void BindFactories()
        {
            BindPlayerFactory();
            BindUIFactory();
            
            void BindPlayerFactory()
            {
                Container
                    .Bind<IGameFactory>()
                    .To<GameFactory>()
                    .AsSingle();
            }

            void BindUIFactory()
            {
                Container
                    .Bind<IUIFactory>()
                    .To<UIFactory>()
                    .AsSingle();
            }
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();
        }
    }
}
