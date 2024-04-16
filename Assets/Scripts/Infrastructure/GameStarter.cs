using Infrastructure.States;
using Zenject;

namespace Infrastructure
{
    public class GameStarter : IInitializable
    {
        private readonly IGameStateMachine _gameplayStateMachine;
        private readonly IUIMediator _uiMediator;

        public GameStarter(IGameStateMachine gameplayStateMachine, StatesFactory gameStateFactory, IUIMediator uiMediator)
        {
            _gameplayStateMachine = gameplayStateMachine;
            _uiMediator = uiMediator;

            _gameplayStateMachine.RegisterState(gameStateFactory.Create<LoadLevelState>());
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<GameLoopState>());
        }

        public void Initialize()
        {
            _uiMediator.InitializeForGameScene();
            
            _gameplayStateMachine.Enter<LoadLevelState>();
        }
    }
}