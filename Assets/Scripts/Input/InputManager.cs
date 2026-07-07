using System;
using UnityEngine;

namespace TurnBased.PlayerInput
{
    public class InputManager : MonoBehaviour, IMoveInput, IMouseInput, IRotationInput, IMouseWheelInput
    {
        public Vector2 MoveInput { get; private set; }
        public Vector2 MousePosition { get; private set; }
        public bool LeftMouseButton { get; private set; }
        public bool RightMouseButton { get; private set; }
        public Vector2 MouseZoomInput {get; private set;}

        public float RotationInput {get; private set; }

        private void Update()
        {
            HorizontalVerticalMovementInput();
            LeftRightRotationInput();
            MouseXYInput();
            MouseClicks();
            MouseWheel();
        }

        private void MouseWheel()
        {
            MouseZoomInput = Input.mouseScrollDelta;
        }

        private void LeftRightRotationInput()
        {
            if(Input.GetKey(KeyCode.E))
            {
                RotationInput = 1f;
            }
            else if(Input.GetKey(KeyCode.Q))
            {
                RotationInput = -1f;
            }
            else
            {
                RotationInput = 0f;
            }
        }

        private void MouseClicks()
        {
            LeftMouseButton = Input.GetMouseButton(0);
            RightMouseButton = Input.GetMouseButton(1);
        }

        private void MouseXYInput()
        {
            MousePosition = Input.mousePosition;
        }

        private void HorizontalVerticalMovementInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            MoveInput = new Vector2(horizontal, vertical);
        }
    }
}
