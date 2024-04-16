using Infrastructure.States;
using UI.Buttons;
using Zenject;

namespace Infrastructure
{
    public class GameStarter : IInitializable
    {
        private readonly IStateMachine _gameplayStateMachine;
        private readonly IUIMediator _uiMediator;

        public GameStarter(IStateMachine gameplayStateMachine, StatesFactory gameStateFactory, IUIMediator uiMediator)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _uiMediator = uiMediator;

            _gameplayStateMachine.RegisterState(gameStateFactory.Create<LoadLevelState>());
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<GameLoopState>());
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<ReloadLevelState>());
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<LevelCompleteState>());
        }

        public void Initialize()
        {
            _uiMediator.InitializeForGameScene();
            
            _uiMediator.AddListenerForGameWonReplayButton(() => _gameplayStateMachine.Enter<ReloadLevelState>());
            _uiMediator.AddListenerForGameLostReplayButton(() => _gameplayStateMachine.Enter<ReloadLevelState>());
            
            _gameplayStateMachine.Enter<LoadLevelState>();
        }
    }
}