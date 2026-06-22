using TurnBased.PlayerInput;
using TurnBased.PlayerView;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.GameBoot
{
    public class GameBootstrapper : MonoBehaviour
    {
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private MouseVisual _cursorVisual;
        [SerializeField] private UnitActionSystem _unitActionSystem;
        [SerializeField] private LevelGrid _levelGrid;

        private void Awake()
        {
            SelectionManager selectionManager = new SelectionManager();
            
            _unitActionSystem.Initialize(selectionManager, _levelGrid);
            _cameraController.Initialize(_inputManager, selectionManager, _unitActionSystem);
            _cursorVisual.Initialize(_cameraController);
        }
    }
}
