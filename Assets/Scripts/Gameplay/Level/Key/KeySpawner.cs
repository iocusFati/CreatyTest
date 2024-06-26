﻿using System;
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
        private readonly IUIMediator _uiMediator;

        private Transform _keyParent;
        
        private readonly List<Key> _spawnedKeys = new();
        
        public event Action OnKeysSpawned;

        public ReactiveProperty<int> UncollectedKeysCount { get; private set; }

        public KeySpawner(IGameFactory gameFactory, IUIMediator uiMediator)
        {
            _gameFactory = gameFactory;
            _uiMediator = uiMediator;
        }

        public void Initialize() => 
            _keyParent = CreateKeyParent();

        public void SpawnKeys(List<Transform> spawnKeysPoints)
        {
            UncollectedKeysCount = new ReactiveProperty<int>(spawnKeysPoints.Count);
            _uiMediator.SetTotalKeysCount(spawnKeysPoints.Count);
            
            foreach (var keySpawn in spawnKeysPoints)
            {
                Key key = _gameFactory.CreateKey(keySpawn.position, _keyParent);
                _spawnedKeys.Add(key);
                
                key.OnGetCollected += OnKeyCollected;
            }
            
            OnKeysSpawned?.Invoke();
        }

        public void RespawnKeys()
        {
            UncollectedKeysCount.Value = _spawnedKeys.Count;
            _uiMediator.ShowKeysCount(UncollectedKeysCount.Value);
            
            foreach (var key in _spawnedKeys)
            {
                key.Respawn();
                key.OnGetCollected += OnKeyCollected;        
            }
            
            OnKeysSpawned?.Invoke();
        }

        private void OnKeyCollected(Key key)
        {
            UncollectedKeysCount.Value--;
            
            _uiMediator.ShowKeysCount(UncollectedKeysCount.Value);
            
            key.OnGetCollected -= OnKeyCollected;
        }

        private static Transform CreateKeyParent() => 
            new GameObject("Keys").transform;
    }
}