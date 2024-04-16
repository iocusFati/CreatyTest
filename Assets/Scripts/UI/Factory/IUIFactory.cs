using Infrastructure.Services;
using Infrastructure.States;

namespace Base.UI.Factory
{
    public interface IUIFactory : IService
    {
        DialogueWindow CreateDialogueWindow();
        HUD CreateHUD();
        GameWonWindow CreateGameWonWindow();
        GameLostWindow CreateGameLostWindow();
        ScreenFader CreateScreenFader();
    }
}