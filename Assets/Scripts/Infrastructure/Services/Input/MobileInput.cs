using UnityEngine;

namespace Infrastructure.Services.Input
{
    public class MobileInput : InputService
    {
        public override bool Tap() => 
            UnityEngine.Input.touches.Length > 0 && UnityEngine.Input.GetTouch(0).phase == TouchPhase.Began;
    }
}