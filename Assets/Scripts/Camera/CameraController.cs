using TurnBased.PlayerInput;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.PlayerView
{
    public class CameraController : MonoBehaviour, IMouseWorldPosition
    {
        [SerializeField] private LayerMask _groundLayer;
        [SerializeField] private LayerMask _unitLayer;
        [SerializeField] private Camera _camera;

        private Ray _ray;
        private RaycastHit _groundHit;
        private IMouseInput _mouseInput;
        private SelectionManager _selectionManager;
        private UnitActionSystem _unitActionSystem;

        public Vector3 MouseWorldPosition { get; private set; }

        public bool HasPosition { get; private set; }

        public void Initialize(IMouseInput mouseInput, SelectionManager selectionManager, UnitActionSystem unitActionSystem)
        {
            _mouseInput = mouseInput;
            _selectionManager = selectionManager;
            _unitActionSystem = unitActionSystem;
        }

        private void Update()
        {
            _ray = _camera.ScreenPointToRay(_mouseInput.MousePosition);

            if (Physics.Raycast(_ray, out RaycastHit groundHit, float.MaxValue, _groundLayer))
            {
                HasPosition = true;
                _groundHit = groundHit;
                MouseWorldPosition = _groundHit.point;
            }

            if (_mouseInput.LeftMouseButton) HandleLeftClick();
            if (_mouseInput.RightMouseButton) HandleRightClick();
        }

        private void HandleLeftClick()
        {
            if (Physics.Raycast(_ray, out RaycastHit unitHit, float.MaxValue, _unitLayer))
            {
                if (unitHit.collider.TryGetComponent<ISelectable>(out var selectable))
                    _selectionManager.Select(selectable);
            }
            else
            {
                _selectionManager.Deselect();
            }
        }

        private void HandleRightClick()
        {
            if (!HasPosition) return;

            _unitActionSystem.MoveUnit(MouseWorldPosition);
        }
    }
}