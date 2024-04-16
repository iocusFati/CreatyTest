namespace Infrastructure.States
{
    public class LevelCompleteState : IPayloadedState<bool>
    {
        private readonly IUIMediator _uiMediator;
        private Player _player;
        
        private bool _hasWon;

        public LevelCompleteState(IUIMediator uiMediator, IGameFactory gameFactory)
        {
            _uiMediator = uiMediator;
            
            gameFactory.OnPlayerCreated += player => _player = player;
        }

        public async void Enter(bool hasWon)
        {
            _hasWon = hasWon;
            
            _uiMediator.HideHUD();
            _player.DisableInput();
            
            await _uiMediator.FadeScreen();

            ShowLevelCompletedWindow(hasWon);
        }

        public void Exit()
        {
            HideLevelCompletedWindow();
        }

        private void ShowLevelCompletedWindow(bool hasWon)
        {
            if (hasWon)
                _uiMediator.ShowGameWonWindow();
            else
                _uiMediator.ShowGameLostWindow();
        }

        private void HideLevelCompletedWindow()
        {
            if (_hasWon)
                _uiMediator.HideGameWonWindow();
            else
                _uiMediator.HideGameLostWindow();
        }
    }
}