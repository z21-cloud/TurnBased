using System;
using TurnBased.PlayerInput;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private Camera _camera;

        private Ray _ray;
        private IMouseInput _mouseInput;
        private IControllable _currentControllable;
        
        public void Initialize(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
        }

        private void Update()
        {
            _ray = GetRay();
            MouseLeftClick();
            MouseRightClick();
        }

        private Ray GetRay()
        {
            return _camera.ScreenPointToRay(_mouseInput.MousePosition);
        }

        private void MouseLeftClick()
        {
            if (!_mouseInput.LeftMouseButton) return;

            if (Physics.Raycast(_ray, out RaycastHit hit) && hit.collider.TryGetComponent<IControllable>(out var controllable))
            {
                _currentControllable = controllable;
            }
        }

        private void MouseRightClick()
        {
            if (!_mouseInput.RightMouseButton || _currentControllable == null) return;

            if (Physics.Raycast(_ray, out RaycastHit hit))
            {
                _currentControllable.SetTargetPosition(hit.point);
            }
        }
    }
}
