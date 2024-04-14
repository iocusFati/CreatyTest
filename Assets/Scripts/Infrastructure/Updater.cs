using System;
using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class Updater : MonoBehaviour, IUpdater
    {
        private readonly List<IUpdatable> _updatables = new();

        private void Awake() => 
            DontDestroyOnLoad(gameObject);

        public void Update()
        {
            foreach (var tickable in _updatables) 
                tickable.Tick();
        }
        
        public void AddTickable(IUpdatable updatable)
        {
            _updatables.Add(updatable);
        }
    }
}