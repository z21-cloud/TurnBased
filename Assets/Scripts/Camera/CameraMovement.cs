using System;
using TurnBased.PlayerInput;
using UnityEngine;

namespace TurnBased.PlayerInput
{
    public class CameraMovement : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 5f;
        [SerializeField] private float _rotationSpeed = 100f;

        private IMoveInput _moveInput;
        private IRotationInput _rotationInput;

        public void Initialize(IMoveInput moveInput, IRotationInput rotationInput)
        {
            _moveInput = moveInput;
            _rotationInput = rotationInput;
        }

        private void Update()
        {
            HandleCameraMovement();
            HandleCameraRotation();
        }

        private void HandleCameraRotation()
        {
            Vector3 rotationVector = new Vector3(0, 0, 0);
            if(_rotationInput.RotationInput > 0)
            {
                rotationVector.y += 1f;
            }
            if(_rotationInput.RotationInput < 0)
            {
                rotationVector.y -= 1f;
            }

            transform.eulerAngles += rotationVector * _rotationSpeed * Time.deltaTime;
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