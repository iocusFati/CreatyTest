using Gameplay.Level;
using Gameplay.Level.Location;
using Infrastructure;
using Infrastructure.States;

namespace UI.Buttons
{
    public class ReloadLevelState : IState
    {
        private readonly IUIMediator _uiMediator;
        private readonly IStateMachine _stateMachine;
        private readonly LevelLocation _location;
        private readonly KeySpawner _keySpawner;

        private Player _player;

        public ReloadLevelState(IGameFactory gameFactory,
            LevelLocation location,
            IUIMediator uiMediator,
            IStateMachine stateMachine, KeySpawner keySpawner)
        {
            _location = location;
            _uiMediator = uiMediator;
            _stateMachine = stateMachine;
            _keySpawner = keySpawner;

            gameFactory.OnPlayerCreated += player => _player = player;
        }

        public async void Enter()
        {
            _keySpawner.RespawnKeys();
            _player.gameObject.SetActive(false);
            _player.transform.position = _location.PlayerSpawnPoint.position;
            _player.gameObject.SetActive(true);
            _location.CloseDoor();
            
            await _uiMediator.UnfadeScreen();
            
            _player.EnableInput();
            _stateMachine.Enter<GameLoopState>();
        }

        public void Exit()
        {
            
        }
    }
}