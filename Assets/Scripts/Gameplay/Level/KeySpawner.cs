using System.Collections.Generic;
using Infrastructure.States;
using UniRx;
using UnityEngine;
using Zenject;

namespace Gameplay.Level
{
    public class KeySpawner : IInitializable, IKeysHolder
    {
        private readonly IGameFactory _gameFactory;
        
        private Transform _keyParent;

        public ReactiveProperty<int> UncollectedKeysCount { get; set; }

        public KeySpawner(IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
        }

        public void Initialize() => 
            _keyParent = CreateKeyParent();

        public void SpawnKeys(List<Transform> spawnKeysPoints)
        {
            UncollectedKeysCount = new ReactiveProperty<int>(spawnKeysPoints.Count);
            
            foreach (var keySpawn in spawnKeysPoints)
            {
                Key key = _gameFactory.CreateKey(keySpawn.position, _keyParent);
            }
        }

        private static Transform CreateKeyParent() => 
            new GameObject("Keys").transform;
    }
}