using System;
using Cysharp.Threading.Tasks;
using Infrastructure.States;
using UnityEngine;

namespace Gameplay.Level
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _getCollectedParticle;
        [SerializeField] private ParticleSystem _keyRotateParticle;
        [SerializeField] private Collider _trigger;

        public event Action<Key> OnGetCollected;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GetCollected();
            }
        }

        public void Respawn()
        {
            _keyRotateParticle.gameObject.SetActive(true);
            _trigger.enabled = true;
        }

        private void GetCollected()
        {
            OnGetCollected?.Invoke(this);
            
            _keyRotateParticle.gameObject.SetActive(false);
            _trigger.enabled = false;
            
            _getCollectedParticle.Play();
        }
    }
}