using System;
using UnityEngine;

namespace TurnBased.PlayerInput
{
    public class InputManager : MonoBehaviour, IMoveInput, IMouseInput
    {
        public Vector2 MoveInput { get; private set; }

        public Vector2 MousePosition { get; private set; }
        public bool LeftMouseButton { get; private set; }
        public bool RightMouseButton { get; private set; }

        private void Update()
        {
            HorizontalVerticalInput();
            MouseXYInput();
            MouseClicks();
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

        private void HorizontalVerticalInput()
        {
            float horizontal = Input.GetAxisRaw("Horizontal");
            float vertical = Input.GetAxisRaw("Vertical");

            MoveInput = new Vector2(horizontal, vertical);
        }
    }
}
