using Infrastructure.Services.Input;
using Infrastructure.Services.StaticDataService;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        
        private PlayerMovement _playerMovement;

        [Inject]
        public void Construct(IInputService inputService, IUpdater updater, IStaticDataService staticData)
        {
            _playerMovement = new PlayerMovement(_characterController, inputService, updater, staticData.PlayerConfig);
        }
    }
}