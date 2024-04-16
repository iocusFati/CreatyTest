using System;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;

namespace Infrastructure.States
{
    public interface IUIMediator
    {
        void InitializeForAllGame();
        void InitializeForGameScene();
        void ShowDialogueWindow();
        void ShowDialogueText(string text);
        void HideDialogueWindow();
        void ShowKeysCount(int count);
        void SetTotalKeysCount(int count);
        void UpdateTimer(int time);
        void ShowTimer();
        void HideTimer();
        void HideHUD();
        void ShowHUD();
        void ShowGameWonWindow();
        void HideGameWonWindow();
        void ShowGameLostWindow();
        void HideGameLostWindow();
        UniTask FadeScreen();
        UniTask UnfadeScreen();
        void AddListenerForGameWonReplayButton(Action onClick);
        void AddListenerForGameLostReplayButton(Action onClick);
    }
}