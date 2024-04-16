using Base.UI.Factory;

namespace Infrastructure.States
{
    public class UIMediator : IUIMediator
    {
        private readonly IUIFactory _uiFactory;
        
        private DialogueWindow _dialogueWindow;
        private HUD _hud;

        public UIMediator(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void InitializeForGameScene()
        {
            _dialogueWindow = _uiFactory.CreateDialogueWindow();
            _hud = _uiFactory.CreateHUD();
            HideTimer();
            
            _dialogueWindow.Hide();
        }

        public void HideDialogueWindow() => _dialogueWindow.Hide();

        public void ShowKeysCount(int count) => _hud.ShowKeysCount(count);
        
        public void SetTotalKeysCount(int count) => _hud.SetTotalKeysCount(count);
        
        public void UpdateTimer(int time) => _hud.UpdateTimer(time);

        public void ShowTimer() => _hud.ShowTimer(true);
        public void HideTimer() => _hud.ShowTimer(false);
        public void HideHUD() => _hud.Hide();
        public void ShowHUD() => _hud.Show();

        public void ShowDialogueWindow() => _dialogueWindow.Show();

        public void ShowDialogueText(string text) => _dialogueWindow.ShowText(text);
    }
}