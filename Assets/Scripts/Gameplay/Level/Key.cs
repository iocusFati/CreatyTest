using Infrastructure.States;
using UnityEngine;

namespace Gameplay.Level
{
    public class Key : MonoBehaviour
    {
        [SerializeField] private ParticleSystem _getCollectedParticle;

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                GetCollected();
            }
        }

        private void GetCollected()
        {
            _getCollectedParticle.Play();
            gameObject.SetActive(false);
        }
    }
}