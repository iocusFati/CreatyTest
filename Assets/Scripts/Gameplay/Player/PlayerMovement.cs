using Infrastructure.Services.Input;
using Infrastructure.StaticData.PlayerData;
using UnityEngine;

namespace Infrastructure.States
{
    public class PlayerMovement : IUpdatable
    {
        private readonly CharacterController _characterController;
        private readonly IInputService _inputService;
        private readonly PlayerConfig _playerConfig;

        public PlayerMovement(CharacterController characterController,
            IInputService inputService,
            IUpdater updater,
            PlayerConfig playerConfig)
        {
            _characterController = characterController;
            _inputService = inputService;
            _playerConfig = playerConfig;
            
            updater.AddTickable(this);
        }

        public void Tick() => 
            _characterController.Move(_inputService.GetMovement() * (_playerConfig.Speed * Time.deltaTime));
    }
}