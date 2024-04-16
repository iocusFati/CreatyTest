using System;
using Infrastructure.Services.Input;
using Infrastructure.Services.StaticDataService;
using Infrastructure.Update;
using UnityEngine;
using Zenject;

namespace Infrastructure.States
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private CharacterController _characterController;
        [SerializeField] private Animator _animator;
        [SerializeField] private Transform _model;

        private PlayerMovement _playerMovement;
        private PlayerAnimator _playerAnimator;

        [Inject]
        public void Construct(IInputService inputService, IUpdater updater, IStaticDataService staticData)
        {
            _playerMovement = new PlayerMovement(_characterController, inputService, updater, staticData.PlayerConfig, _model);
            _playerAnimator = new PlayerAnimator(_animator, updater, inputService);
        }

        public void DisableInput()
        {
            _playerMovement.DisableInput();
            _playerAnimator.DisableInput();
        }

        public void EnableInput()
        {
            _playerMovement.EnableInput();
            _playerAnimator.EnableInput();
        }
    }
}