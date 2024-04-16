using System;
using Base.UI.Entities.Windows;
using UnityEngine;
using UnityEngine.UI;

namespace Infrastructure.States
{
    public class LevelCompleteWindow : Window
    {
        [SerializeField] private Button _replayButton;

        public void AddListenerToReplyButton(Action onButtonClicked) => 
            _replayButton.onClick.AddListener(onButtonClicked.Invoke);
    }
}