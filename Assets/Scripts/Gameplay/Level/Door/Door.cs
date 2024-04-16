using System.Collections;
using System.Collections.Generic;
using Infrastructure.Services.StaticDataService;
using Infrastructure.StaticData.Level;
using UnityEngine;
using Zenject;

namespace Gameplay.Level
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Collider _doorExitTrigger;
        [SerializeField] private float _targetJointPosition;
        [SerializeField] private float _doorOpenSpeed;
        [SerializeField] private List<DoorPartData> _doorParts;

        private LocationConfig _locationConfig;

        [Inject]
        public void Construct(IStaticDataService staticData)
        {
            _locationConfig = staticData.LocationConfig;
        }

        public void Open()
        {
            ActivateDoorExitTrigger(true);
            
            foreach (var part in _doorParts) 
                StartCoroutine(OpenDoorPart(part));
        }

        public void Close()
        {
            ActivateDoorExitTrigger(false);
            
            foreach (var part in _doorParts)
            {
                HingeJoint doorPartJoint = part.Joint;
                JointSpring spring = doorPartJoint.spring;
                
                spring.targetPosition = 0;
                doorPartJoint.spring = spring;
            }
        }

        private void ActivateDoorExitTrigger(bool activate) => 
            _doorExitTrigger.enabled = activate;

        private IEnumerator OpenDoorPart(DoorPartData doorPart)
        {
            HingeJoint doorPartJoint = doorPart.Joint;
            JointSpring spring = doorPartJoint.spring;

            float direction = doorPart.Sign == Sign.Positive ? 1 : -1;

            while (Mathf.Abs(spring.targetPosition) < Mathf.Abs(_locationConfig.DoorOpenAngle))
            {
                spring.targetPosition += direction * Time.deltaTime * _locationConfig.DoorOpenSpeed;
                
                doorPartJoint.spring = spring;
                
                yield return null;
            }
        }
    }
}