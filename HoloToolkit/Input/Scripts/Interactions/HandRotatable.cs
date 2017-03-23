using UnityEngine;

namespace HoloToolkit.Unity.InputModule
{
    public class HandRotatable : MonoBehaviour, IInputHandler
    {
        public bool IsRotationEnabled = true;

        public float RotationSpeed = 0.5f;

        private bool IsPressed;

        private Transform menuParent;

        public void OnInputDown(InputEventData eventData)
        {
            IsPressed = true;
        }

        public void OnInputUp(InputEventData eventData)
        {
            IsPressed = false;
        }

        private void Update()
        {
            if (IsRotationEnabled && IsPressed)
            {
                transform.Rotate(0, RotationSpeed, 0);
            }
        }
    }
}
