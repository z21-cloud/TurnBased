using System;
using TurnBased.PlayerInput;
using UnityEngine;

namespace TurnBased.PlayerInput
{
    public class CameraMovement : MonoBehaviour, ICameraBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;

        private IMoveInput _moveInput;

        public void Initialize(IMoveInput moveInput)
        {
            _moveInput = moveInput;
        }

        public void Tick()
        {
            HandleCameraMovement();
        }

        private void HandleCameraMovement()
        {
            Vector3 moveDirection = new Vector3(0, 0, 0);

            if(_moveInput.MoveInput.x > 0)
            {
                moveDirection.x += 1f;
            }
            if(_moveInput.MoveInput.x < 0)
            {
                moveDirection.x -= 1f;
            }
            if(_moveInput.MoveInput.y > 0)
            {
                moveDirection.z += 1f;
            }
            if(_moveInput.MoveInput.y < 0)
            {
                moveDirection.z -= 1f;
            }

            Vector3 moveVector = transform.forward * moveDirection.z + transform.right * moveDirection.x;
            transform.position += moveVector * _moveSpeed * Time.deltaTime;
        }
    }
}