using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class InputService : IInputService
    {
        public Vector3 GetMovement()
        {
            float moveHorizontal = UnityEngine.Input.GetAxis("Horizontal");
            float moveVertical = UnityEngine.Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

            return movement.normalized;
        }

        public bool PressEnter() => 
            UnityEngine.Input.GetKeyDown(KeyCode.Return);
    }
}