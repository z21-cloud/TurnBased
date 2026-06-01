using UnityEngine;

namespace TurnBased.PlayerInput
{
    public class InputManager : MonoBehaviour, IMoveInput
    {
        public Vector2 Move { get; private set; }

        private void Update()
        {
            HorizontalVerticalInput();
        }

        private void HorizontalVerticalInput()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Horizontal");

            Move = new Vector2(horizontal, vertical);
        }
    }
}
