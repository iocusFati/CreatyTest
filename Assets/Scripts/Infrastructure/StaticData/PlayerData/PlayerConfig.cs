using UnityEngine;

namespace Infrastructure.StaticData.PlayerData
{
    [CreateAssetMenu(fileName = "PlayerConfig", menuName = "Configs/PlayerConfig")]
    public class PlayerConfig : ScriptableObject
    {
        [SerializeField] private float _speed;

        public float Speed => _speed;
    }
}