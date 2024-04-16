using UnityEngine;

namespace Infrastructure.StaticData.PlayerData
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _speed;

        [Header("PlusOneText")]
        [SerializeField] private float _plusOneTextRaiseBy;
        [SerializeField] private float _plusOneTextRaiseDuration;
        [SerializeField] private float _plusOneTextSpawnHeight;

        public float Speed => _speed;

        public float PlusOneTextSpawnHeight => _plusOneTextSpawnHeight;

        public float PlusOneTextRaiseBy => _plusOneTextRaiseBy;

        public float PlusOneTextRaiseDuration => _plusOneTextRaiseDuration;
    }
}