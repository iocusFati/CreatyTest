using System.Threading;
using Cysharp.Threading.Tasks;
using Gameplay.Level;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.Level;
using UniRx;
using Timer = Gameplay.Level.Plot.Timer;

namespace Infrastructure.States
{
    public class GameLoopState : IState
    {
        private readonly IKeysHolder _keysHolder;
        private readonly LevelPlot _levelPlot;
        private readonly LevelPlotConfig _levelPlotConfig;
        private readonly IUIMediator _uiMediator;
        private readonly IStateMachine _stateMachine;
        private readonly Timer _timer;
        
        private CompositeDisposable _keyDisposable;

        public GameLoopState(IStaticDataService staticData,
            IKeysHolder keysHolder,
            LevelPlot levelPlot,
            Timer timer,
            IUIMediator uiMediator,
            IStateMachine stateMachine)
        {
            _keysHolder = keysHolder;
            _levelPlot = levelPlot;
            _levelPlotConfig = staticData.LevelPlotConfig;
            _timer = timer;
            _uiMediator = uiMediator;
            _stateMachine = stateMachine;
            
            _keyDisposable = new CompositeDisposable();

            _keysHolder.OnKeysSpawned += SubscribeForKeys;
        }

        public async void Enter()
        {
            await _levelPlot.StartPlot(_levelPlotConfig.LevelStartPlot);

            _timer.ResetTimer();
            _uiMediator.ShowTimer();
            
            _timer.OnTimerEnd += () =>
            {
                _stateMachine.Enter<LevelCompleteState, bool>(false);
                UnsubscribeFromKeys();
            };
        }

        public void Exit()
        {
            
        }

        private void SubscribeForKeys()
        {
            SubscribeToFirstKeyPick();
            SubscribeToAllKeysCollected();
        }

        private void UnsubscribeFromKeys() => 
            _keyDisposable.Clear();

        private void SubscribeToFirstKeyPick() =>
            _keysHolder.UncollectedKeysCount
                .Skip(1)
                .Take(1)
                .Subscribe(_ => _levelPlot.StartPlot(_levelPlotConfig.FirstKeyPickedPlot).Forget())
                .AddTo(_keyDisposable);

        private void SubscribeToAllKeysCollected() =>
            _keysHolder.UncollectedKeysCount
                .Where(currentCount => currentCount == 0)
                .Take(1)
                .Subscribe(_ => _levelPlot.StartPlot(_levelPlotConfig.AllKeysCollectedPlot).Forget())
                .AddTo(_keyDisposable);
    }
}