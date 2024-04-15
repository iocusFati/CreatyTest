using Infrastructure.States;
using Zenject;

namespace Infrastructure
{
    public class GameStarter : IInitializable
    {
        private readonly IGameStateMachine _gameplayStateMachine;

        public GameStarter(IGameStateMachine gameplayStateMachine, StatesFactory gameStateFactory)
        {
            _gameplayStateMachine = gameplayStateMachine;
         
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<LoadLevelState>());
            _gameplayStateMachine.RegisterState(gameStateFactory.Create<GameLoopState>());
        }

        public void Initialize()
        {
            _gameplayStateMachine.Enter<LoadLevelState>();
        }
    }
}