using Base.UI.Entities.Windows;
using DG.Tweening;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.UI;
using Sirenix.OdinInspector;
using TMPro;
using UnityEngine;
using Zenject;

namespace Base.UI.Factory
{
    public class HUD : Window 
    {
        [SerializeField] private TextMeshProUGUI _keyCountText;
        
        [Header("Timer")]
        [SerializeField] private TextMeshProUGUI _timerText;
        [SerializeField] private GameObject _timerContainer;

        private UIConfig _uiConfig;

        private int _currentKeysCount;
        private int _totalKeysCount;

        [Inject]
        public void Construct(IStaticDataService staticData)
        {
            _uiConfig = staticData.UIConfig;
        }
        
        [Button]
        public void ShowKeysCount(int keysLeft)
        {
            _currentKeysCount = _totalKeysCount - keysLeft;
            
            SetKeysCountText(doPunch: true);
        }

        public void SetTotalKeysCount(int count)
        {
            _totalKeysCount = count;
            SetKeysCountText();
        }

        public void UpdateTimer(int time)
        {
            int minutes = time / 60;
            int seconds = time % 60;
            
            _timerText.text = $"{minutes:D2}:{seconds:D2}";
        }

        public void ShowTimer(bool show) => 
            _timerContainer.gameObject.SetActive(show);

        private void SetKeysCountText(bool doPunch = false)
        {
            _keyCountText.text = $"{_currentKeysCount}/{_totalKeysCount}";

            if (doPunch)
                _keyCountText.transform
                    .DOPunchScale(Vector3.one * _uiConfig.TextPunchScale, _uiConfig.TextPunchDuration,
                        _uiConfig.TextPunchVibrato, _uiConfig.TextPunchElasticity);
        }
    } 
}