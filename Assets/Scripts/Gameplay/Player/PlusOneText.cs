using DG.Tweening;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.PlayerData;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class PlusOneText : MonoBehaviour
    {
        private PlayerConfig _playerConfig;
        
        private CanvasGroup _canvasGroup;
        private Transform _cameraTransform;
        private RectTransform _rectTransform;

        [Inject]
        public void Construct(IStaticDataService staticDataService)
        {
            _playerConfig = staticDataService.PlayerConfig;
        }
        
        private void Awake()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
            _rectTransform = GetComponent<RectTransform>();
            _cameraTransform = Camera.main.transform;
        }

        [Button]
        public void RaiseText(Transform player)
        {
            transform.position = new Vector3(player.position.x, _playerConfig.PlusOneTextSpawnHeight, player.position.z);
            transform
                .DOMoveY(transform.position.y + _playerConfig.PlusOneTextRaiseBy, _playerConfig.PlusOneTextRaiseDuration)
                .OnUpdate(() => transform.LookAt(_cameraTransform.position))
                .OnComplete(() => _rectTransform.anchoredPosition = Vector2.zero);
            
            FadeText();
        }

        private void FadeText()
        {
            _canvasGroup.alpha = 1;
            DOTween.To(() => _canvasGroup.alpha,
                alpha => _canvasGroup.alpha = alpha,
                0, _playerConfig.PlusOneTextRaiseDuration);
        }
    }
}