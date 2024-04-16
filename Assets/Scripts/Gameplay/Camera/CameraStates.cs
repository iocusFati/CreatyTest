using System;
using Cinemachine;
using Cysharp.Threading.Tasks;
using Infrastructure.StaticData.Level;
using UnityEngine;

namespace Infrastructure.States
{
    public class CameraStates : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private CinemachineStateDrivenCamera _stateDrivenCamera;

        private readonly int _gradualDoorId = Animator.StringToHash("GradualDoor");
        private readonly int _cutDoorId = Animator.StringToHash("CutDoor");
        private int _currentStateId;

        public async UniTask SwitchCameraState(AnimationCameraState cameraState)
        {
            ExitCurrentState();
            
            switch (cameraState)
            {
                case AnimationCameraState.DoorGradual:
                    GoToGradualDoor();
                    break;
                case AnimationCameraState.DoorCut:
                    GoToCutDoor();
                    break;
                case AnimationCameraState.PlayerFollow:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(cameraState), cameraState, null);
            }
            
            await UniTask.DelayFrame(20);
            Debug.Log(_stateDrivenCamera.IsBlending);
            await WaitUntilCamerasFinishedBlending();
        }

        private UniTask WaitUntilCamerasFinishedBlending() => 
            UniTask.WaitUntil(() => !_stateDrivenCamera.IsBlending);

        private void ExitCurrentState()
        {
            if (_currentStateId != 0) 
                _animator.SetBool(_currentStateId, false);
        }

        private void GoToCutDoor()
        {
            _currentStateId = _cutDoorId; 
            _animator.SetBool(_cutDoorId, true);
        }

        private void GoToGradualDoor()
        {
            _currentStateId = _gradualDoorId;
            _animator.SetBool(_gradualDoorId, true);
        }
    }
}