using System.Collections.Generic;
using UnityEngine;

namespace Infrastructure
{
    public class Ticker : MonoBehaviour, ITicker
    {
        private readonly List<ITickable> _tickables = new();
        
        public void Update()
        {
            foreach (var tickable in _tickables) 
                tickable.Tick();
        }
        
        public void AddTickable(ITickable tickable)
        {
            _tickables.Add(tickable);
        }
    }
}