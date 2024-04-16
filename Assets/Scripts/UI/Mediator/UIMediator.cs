using System;
using Base.UI.Entities.Windows;
using Base.UI.Factory;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Infrastructure.States
{
    public class UIMediator : IUIMediator
    {
        private readonly IUIFactory _uiFactory;
        
        private DialogueWindow _dialogueWindow;
        private HUD _hud;
        private GameWonWindow _gameWonWindow;
        private GameLostWindow _gameLostWindow;
        private ScreenFader _screenFader;

        public UIMediator(IUIFactory uiFactory)
        {
            _uiFactory = uiFactory;
        }

        public void InitializeForAllGame()
        {
            _screenFader = _uiFactory.CreateScreenFader();

            SetDontDestroyOnLoadParent(out var dontDestroyOnLoadParent);

            Object.DontDestroyOnLoad(dontDestroyOnLoadParent);

            
            void SetDontDestroyOnLoadParent(out GameObject dontDestroyOnLoad)
            {
                dontDestroyOnLoad  = new GameObject("DontDestroyUI");
                _screenFader.transform.SetParent(dontDestroyOnLoad.transform);
            }
        }

        public void InitializeForGameScene()
        {
            _dialogueWindow = _uiFactory.CreateDialogueWindow();
            _hud = _uiFactory.CreateHUD();
            _gameWonWindow = _uiFactory.CreateGameWonWindow();
            _gameLostWindow = _uiFactory.CreateGameLostWindow();
            
            HideTimer();
            _dialogueWindow.Hide();
            _gameWonWindow.Hide();
            _gameLostWindow.Hide();
        }

        public void HideDialogueWindow() => _dialogueWindow.Hide();

        public void ShowKeysCount(int count) => _hud.ShowKeysCount(count);
        
        public void SetTotalKeysCount(int count) => _hud.SetTotalKeysCount(count);
        
        public void UpdateTimer(int time) => _hud.UpdateTimer(time);

        public void ShowTimer() => _hud.ShowTimer(true);
        public void HideTimer() => _hud.ShowTimer(false);
        public void HideHUD() => _hud.Hide();
        public void ShowHUD() => _hud.Show();
        public void ShowGameWonWindow() => _gameWonWindow.Show();
        public void HideGameWonWindow() => _gameWonWindow.Hide();
        public void ShowGameLostWindow() => _gameLostWindow.Show();
        public void HideGameLostWindow() => _gameLostWindow.Hide();

        public async UniTask FadeScreen() => await _screenFader.FadeAsync();

        public async UniTask UnfadeScreen() => await _screenFader.UnfadeAsync();
        public void AddListenerForGameWonReplayButton(Action onClick) => 
            _gameWonWindow.AddListenerToReplyButton(onClick);

        public void AddListenerForGameLostReplayButton(Action onClick) => 
            _gameLostWindow.AddListenerToReplyButton(onClick);

        public void ShowDialogueWindow() => _dialogueWindow.Show();

        public void ShowDialogueText(string text) => _dialogueWindow.ShowText(text);
    }
}