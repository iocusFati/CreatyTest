using Infrastructure.Services.Input;
using Infrastructure.Update;
using UnityEngine;

namespace Infrastructure.States
{
    public class PlayerAnimator : IUpdatable
    {
        private readonly Animator _animator;
        private readonly IInputService _inputService;
        
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        
        private bool _inputEnabled;

        public PlayerAnimator(Animator animator, IUpdater updater, IInputService inputService)
        {
            _animator = animator;
            _inputService = inputService;

            updater.AddUpdatable(this);
        }

        public void Update()
        {
            if (!_inputEnabled)
                return;
            
            _animator.SetBool(IsRunning, _inputService.GetMovement().magnitude > 0);
        }

        public void DisableInput()
        {
            _inputEnabled = false;
            _animator.SetBool(IsRunning, false);
        }

        public void EnableInput() => 
            _inputEnabled = true;
    }
}