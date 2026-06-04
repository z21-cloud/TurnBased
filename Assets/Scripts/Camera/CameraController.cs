using TurnBased.PlayerInput;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class CameraController : MonoBehaviour, IMouseWorldPosition
    {
        [SerializeField] private LayerMask _mouseLayer;
        [SerializeField] private Camera _camera;

        private Ray _ray;
        private RaycastHit _hit;
        private IMouseInput _mouseInput;
        private IControllable _currentControllable;

        public Vector3 MouseWorldPosition { get; private set; }

        public bool HasPosition { get; private set; }

        public void Initialize(IMouseInput mouseInput)
        {
            _mouseInput = mouseInput;
        }

        private void Update()
        {
            _ray = GetRay();

            if(Physics.Raycast(_ray, out RaycastHit hit, float.MaxValue, _mouseLayer))
            {
                HasPosition = true;
                _hit = hit;       

                MouseWorldPosition = _hit.point;        
            }

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

            if (_hit.collider.TryGetComponent<IControllable>(out var controllable))
            {
                _currentControllable = controllable;
            }
        }

        private void MouseRightClick()
        {
            if (!_mouseInput.RightMouseButton || _currentControllable == null) return;

            _currentControllable.SetTargetPosition(MouseWorldPosition);
        }
    }
}
