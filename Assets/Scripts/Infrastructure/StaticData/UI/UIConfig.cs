using UnityEngine;

namespace Infrastructure.StaticData.UI
{
    [CreateAssetMenu(fileName = "UIConfig", menuName = "Configs/UIConfig")]
    public class UIConfig : ScriptableObject
    {
        [Header("Text Punch")]
        [SerializeField] private float _textPunchScale;
        [SerializeField] private float _textPunchDuration;
        [SerializeField] private int _textPunchVibrato;
        [SerializeField] private float _textPunchElasticity;

        public float TextPunchScale => _textPunchScale;

        public float TextPunchDuration => _textPunchDuration;

        public int TextPunchVibrato => _textPunchVibrato;

        public float TextPunchElasticity => _textPunchElasticity;
    }
}