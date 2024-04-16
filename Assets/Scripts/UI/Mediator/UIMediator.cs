using Base.UI.Factory;

namespace Infrastructure.States
{
    public class UIMediator : IUIMediator
    {
        private readonly IUIFactory _uiFactory;
        
        private DialogueWindow _dialogueWindow;

        public UIMediator(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void InitializeForGameScene()
        {
            _dialogueWindow = _uiFactory.CreateDialogueWindow();
            
            _dialogueWindow.Hide();
        }

        public void HideDialogueWindow() => 
            _dialogueWindow.Hide();

        public void ShowDialogueWindow() => 
            _dialogueWindow.Show();

        public void ShowDialogueText(string text) => 
            _dialogueWindow.ShowText(text);
    }
}