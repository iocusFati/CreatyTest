using UnityEngine;

namespace Infrastructure.StaticData.Level
{
    [CreateAssetMenu(fileName = "LocationConfig", menuName = "Configs/LocationConfig")]
    public class LocationConfig : ScriptableObject
    {
        [Header("Door")]
        [SerializeField] private float _doorOpenAngle;
        [SerializeField] private float _doorOpenSpeed;

        public float DoorOpenAngle => _doorOpenAngle;

        public float DoorOpenSpeed => _doorOpenSpeed;
    }
}