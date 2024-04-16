namespace Infrastructure.States
{
    public interface IUIMediator
    {
        void ShowDialogueWindow();
        void ShowDialogueText(string text);
        void InitializeForGameScene();
        void HideDialogueWindow();
    }
}