using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class StandaloneInput : InputService
    {
        public override bool Tap() => 
            UnityEngine.Input.GetKeyDown(KeyCode.Space);
    }
}