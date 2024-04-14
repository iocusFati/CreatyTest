using System;
using System.Collections;
using Infrastructure.AssetProviderService;
using Infrastructure.Services.Input;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Infrastructure.Services.StaticDataService;
using Infrastructure.States;
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
            BindStatesFactory();
            BindCoroutineRunner();
            BindGameStateMachine();
            BindSaveLoadService();
            BindPersistentProgress();
            BindAssetsService();

            BindFactories();
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

            void BindPlayerFactory()
            {
                Container
                    .Bind<IPlayerFactory>()
                    .To<PlayerFactory>()
                    .AsSingle();
            }
        }

        private void BindSceneLoader()
        {
            Container
                .Bind<SceneLoader>()
                .AsSingle();
        }

        private void BindStatesFactory()
        {
            Container
                .BindInterfacesAndSelfTo<StatesFactory>()
                .AsSingle();
        }

        private void BindCoroutineRunner()
        {
            Container
                .Bind<ICoroutineRunner>()
                .FromInstance(this)
                .AsSingle();
        }
        
        private void BindGameStateMachine()
        {
            Container
                .Bind<IGameStateMachine>()
                .To<GameStateMachine>()
                .FromInstance(new GameStateMachine())
                .AsSingle();
        }

        public void DoAfter(Func<bool> condition, Action action) => 
            StartCoroutine(DoAfterCoroutine(condition, action));

        private IEnumerator DoAfterCoroutine(Func<bool> condition, Action action)
        {
            yield return new WaitUntil(condition);

            Debug.Log("Action");
            action.Invoke();
        }
    }
}
