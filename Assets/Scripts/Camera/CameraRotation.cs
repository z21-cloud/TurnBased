using TurnBased.PlayerInput;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class CameraRotation : MonoBehaviour, ICameraBehaviour
    {
        [SerializeField] private float _rotationSpeed = 100f;

        private IRotationInput _rotationInput;

        public void Initialize(IRotationInput rotationInput)
        {
            _rotationInput = rotationInput;
        }

        public void Tick()
        {
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
    }
}

