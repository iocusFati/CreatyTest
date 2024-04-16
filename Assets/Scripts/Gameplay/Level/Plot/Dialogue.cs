namespace Infrastructure.States
{
    public class Dialogue
    {
        private readonly IUIMediator _uiMediator;

        public Dialogue(IUIMediator uiMediator)
        {
            _uiMediator = uiMediator;
        }

        public void StartDialogue(string text)
        {
            _uiMediator.ShowDialogueWindow();
            _uiMediator.ShowDialogueText(text);
        }

        public void HideDialogue()
        {
            _uiMediator.HideDialogueWindow();
        }
    }
}