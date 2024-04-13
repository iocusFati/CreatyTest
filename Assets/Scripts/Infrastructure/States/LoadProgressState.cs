using Infrastructure.Data;
using Infrastructure.Services.PersistentProgress;
using Infrastructure.Services.SaveLoad;
using Zenject;

namespace Infrastructure.States
{
    public class LoadProgressState : IState
    {
        private const string MainSceneName = "Game";
        
        private readonly IGameStateMachine _gameStateMachine;
        private readonly IPersistentProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState() { }
        
        public LoadProgressState(
            IGameStateMachine gameStateMachine, 
            IPersistentProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _gameStateMachine = gameStateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            LoadProgressOrInitNew();
            
            _gameStateMachine.Enter<LoadLevelState, string>(MainSceneName);
        }

        public void Exit()
        {
            
        }

        private void LoadProgressOrInitNew()
        {
            _progressService.Progress =
                _saveLoadService.LoadProgress() != null ? _saveLoadService.LoadProgress() : NewProgress();
        }

        private PlayerProgress NewProgress() => new();
    }
}