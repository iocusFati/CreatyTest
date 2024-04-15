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

        public PlayerAnimator(Animator animator, IUpdater updater, IInputService inputService)
        {
            _animator = animator;
            _inputService = inputService;

            updater.AddUpdatable(this);
        }

        public void Tick()
        {
            _animator.SetBool(IsRunning, _inputService.GetMovement().magnitude > 0);
        }
    }
}