using System.Collections.Generic;
using UnityEngine;

namespace Gameplay.Level.Location
{
    public class LevelLocation : MonoBehaviour
    {
        [SerializeField] private List<Transform> _keySpawnPositions;
        [SerializeField] private Transform _playerSpawnPoint;
        [SerializeField] private Door _door;

        public List<Transform> KeySpawnPositions => _keySpawnPositions;

        public Transform PlayerSpawnPoint => _playerSpawnPoint;

        private void Awake()
        {
            OpenDoor();
        }

        public void OpenDoor()
        {
            _door.Open();
        }
    }
}