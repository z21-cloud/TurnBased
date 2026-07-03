using TurnBased.PlayerInput;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class CameraController : MonoBehaviour
    {
        private ICameraBehaviour _cameraInputHandler;
        private ICameraBehaviour _cameraMovement;
        private ICameraBehaviour _cameraRotation;
        public void Initialize(ICameraBehaviour cameraInputHandler, ICameraBehaviour cameraMovement, ICameraBehaviour cameraRotation)
        {
            _cameraInputHandler = cameraInputHandler;
            _cameraMovement = cameraMovement;
            _cameraRotation = cameraRotation;
        }

        private void Update()
        {
            if(_cameraInputHandler == null || _cameraMovement == null)
            {
                Debug.LogError($"[CameraController]: Wrong Initialization!");
                return;
            }

            _cameraInputHandler.Tick();
            _cameraMovement.Tick();
            _cameraRotation.Tick();
        }
    }
}