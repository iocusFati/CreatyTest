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
        private IStateMachine _gameplayStateMachine;

        public PlusOneText PlusOneText { get; set; }

        [Inject]
        public void Construct(IInputService inputService, IUpdater updater, IStaticDataService staticData,
            IStateMachine gameplayStateMachine)
        {
            _gameplayStateMachine = gameplayStateMachine;
            
            _playerMovement = new PlayerMovement(_characterController, inputService, updater, staticData.PlayerConfig, _model);
            _playerAnimator = new PlayerAnimator(_animator, updater, inputService);
        }
        
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Key))
            {
                PlusOneText.RaiseText(transform);
            }
            else if (other.CompareTag(Tags.DoorExit))
            {
                _gameplayStateMachine.Enter<LevelCompleteState, bool>(true);
            }
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