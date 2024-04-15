using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Gameplay.Level
{
    public class LevelLocation : MonoBehaviour
    {
        [SerializeField] private List<Transform> _keySpawnPositions;
        [FormerlySerializedAs("_playerSpawnPosition")] [SerializeField] private Transform _playerSpawnPoint;

        public List<Transform> KeySpawnPositions => _keySpawnPositions;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;
    }
}