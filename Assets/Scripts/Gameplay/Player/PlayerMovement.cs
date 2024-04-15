using Infrastructure.Services.Input;
using Infrastructure.StaticData.PlayerData;
using Infrastructure.Update;
using UnityEngine;

namespace Infrastructure.States
{
    public class PlayerMovement : IUpdatable
    {
        private readonly CharacterController _characterController;
        private readonly IInputService _inputService;
        private readonly PlayerConfig _playerConfig;
        private readonly Transform _playerModel;
        
        private Camera _camera;

        public PlayerMovement(CharacterController characterController,
            IInputService inputService,
            IUpdater updater,
            PlayerConfig playerConfig, 
            Transform playerModel)
        {
            _characterController = characterController;
            _inputService = inputService;
            _playerConfig = playerConfig;
            _playerModel = playerModel;

            updater.AddUpdatable(this);
        }
        
        public void SetCamera(Camera camera)
        {
            _camera = camera;
        }

        public void Tick()
        {
            Vector3 movementDirection = _inputService.GetMovement();
            
            if (_inputService.GetMovement() != Vector3.zero) 
                _playerModel.forward = movementDirection;

            _characterController.Move(movementDirection * (_playerConfig.Speed * Time.deltaTime));
        }
    }
}