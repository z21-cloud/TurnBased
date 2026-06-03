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

        public RaycastHit CurrentHit { get; private set; }
        public bool HasHit { get; private set; }

        public void Initialize(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
        }

        private void Update()
        {
            _ray = GetRay();

            HasHit = Physics.Raycast(_ray, out RaycastHit hit);

            if(HasHit) CurrentHit = hit;

            MouseLeftClick(CurrentHit);
            MouseRightClick(CurrentHit);
        }

        private Ray GetRay()
        {
            return _camera.ScreenPointToRay(_mouseInput.MousePosition);
        }

        private void MouseLeftClick(RaycastHit hit)
        {
            if (!_mouseInput.LeftMouseButton) return;

            if (hit.collider.TryGetComponent<IControllable>(out var controllable))
            {
                _currentControllable = controllable;
            }
        }

        private void MouseRightClick(RaycastHit hit)
        {
            if (!_mouseInput.RightMouseButton || _currentControllable == null) return;

            _currentControllable.SetTargetPosition(hit.point);
        }
    }
}
