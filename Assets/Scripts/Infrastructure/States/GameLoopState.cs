using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Level;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.Level;
using UniRx;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IKeysHolder _keysHolder;
        private readonly LevelPlot _levelPlot;
        private readonly LevelPlotConfig _levelPlotConfig;

        private CompositeDisposable _firstKeyPickedDisposable;
        private CompositeDisposable _allKeysCollectedDisposable;

        public GameLoopState(IStaticDataService staticData, IKeysHolder keysHolder, LevelPlot levelPlot)
        {
            _keysHolder = keysHolder;
            _levelPlot = levelPlot;
            _levelPlotConfig = staticData.LevelPlotConfig;
            
            _keysHolder.OnKeysSpawned += SubscribeForKeys;
        }

        public void Enter()
        {
            Initialize();
            
            _levelPlot.StartPlot(_levelPlotConfig.LevelStartPlot).Forget();
        }

        public void Exit()
        {
            
        }

        private void Initialize()
        {
            
        }

        private void SubscribeForKeys()
        {
            SubscribeToFirstKeyPick();
            SubscribeToAllKeysCollected();
        }

        private void SubscribeToFirstKeyPick() =>
            _keysHolder.UncollectedKeysCount
                .Skip(1)
                .Take(1)
                .Subscribe(_ => _levelPlot.StartPlot(_levelPlotConfig.FirstKeyPickedPlot).Forget());

        private void SubscribeToAllKeysCollected() =>
            _keysHolder.UncollectedKeysCount
                .Where(currentCount => currentCount == 0)
                .Take(1)
                .Subscribe(_ => _levelPlot.StartPlot(_levelPlotConfig.AllKeysCollectedPlot).Forget());
    }
}