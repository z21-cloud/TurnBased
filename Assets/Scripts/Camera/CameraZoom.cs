using TurnBased.PlayerInput;
using UnityEngine;
using Unity.Cinemachine;

namespace TurnBased.PlayerView
{
    public class CameraZoom : MonoBehaviour, ICameraBehaviour
    {
        [SerializeField] private CinemachineCamera _cinemachineCamera;
        [SerializeField] private float _zoomAmount = 1f;
        [SerializeField] private float _zoomSpeed = 5f;
        private const float MIN_Y_OFFSET = 2f;
        private const float MAX_Y_OFFSET = 12f;
        private IMouseWheelInput _mouseWheelInput;

        private CinemachineFollow _cinemachineFollow;
        public void Initialize(IMouseWheelInput mouseWheelInput)
        {
            _mouseWheelInput = mouseWheelInput;

            _cinemachineFollow = _cinemachineCamera.GetCinemachineComponent(CinemachineCore.Stage.Body) as CinemachineFollow;
        }
        public void Tick()
        {
            HandleMouseZoom();
        }

        private void HandleMouseZoom()
        {
            Vector3 followOffset = _cinemachineFollow.FollowOffset;

            if(_mouseWheelInput.MouseZoomInput.y > 0)
            {
               followOffset.y -= _zoomAmount;
            }
            if(_mouseWheelInput.MouseZoomInput.y < 0)
            {
                followOffset.y += _zoomAmount;
            }
            followOffset.y = Mathf.Clamp(followOffset.y, MIN_Y_OFFSET, MAX_Y_OFFSET);
            
            _cinemachineFollow.FollowOffset = Vector3.Lerp(_cinemachineFollow.FollowOffset, followOffset, _zoomSpeed * Time.deltaTime);
            
        }
    }
}
