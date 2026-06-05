using TurnBased.PlayerInput;
using TurnBased.PlayerView;
using UnityEngine;

namespace TurnBased.GameBoot
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private MouseVisual _cursorVisual;
        [SerializeField] private SelectionManager _selectionManager;
        [SerializeField] private UnitActionSystem _unitActionSystem;

        private void Awake()
        {
            _unitActionSystem.Initialize(_selectionManager);
            _cameraController.Initialize(_inputManager, _selectionManager, _unitActionSystem);
            _cursorVisual.Initialize(_cameraController);
        }
    }
}
