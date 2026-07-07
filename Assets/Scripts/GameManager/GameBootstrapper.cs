using System.Collections.Generic;
using TurnBased.Pathfinding;
using TurnBased.PlayerInput;
using TurnBased.PlayerView;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.GameBoot
{
    public class GameBootstrapper : MonoBehaviour
    {
        [Header("Camera Initialization")]
        [SerializeField] private CameraInputHandler _cameraInputHandler;
        [SerializeField] private CameraRotation _cameraRotation;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private CameraZoom _cameraZoom;
        
        [Header("Cursos Initialization")]
        [SerializeField] private MouseVisual _cursorVisual;
        
        [Header("Input Initialization")]
        [SerializeField] private InputManager _inputManager;
        
        [Header("Grid Initialization")]
        [SerializeField] private LevelGrid _levelGrid;
        [SerializeField] private List<UnitController> _units;

        private void Awake()
        {
            SelectionManager selectionManager = new();
            UnitActionSystem unitActionSystem = new();

            unitActionSystem.Initialize(selectionManager, _levelGrid);

            HandleCameraInitialization(selectionManager, unitActionSystem);

            foreach (var unit in _units)
            {
                unit.Initialize(_levelGrid.GetCenterNodePosition(unit.StartPosition));

                _levelGrid.RegisterUnit(unit, unit.WorldPosition);
            }
        }

        private void HandleCameraInitialization(SelectionManager selectionManager, UnitActionSystem unitActionSystem)
        {
            _cursorVisual.Initialize(_cameraInputHandler);
            _cameraInputHandler.Initialize(_inputManager, selectionManager, unitActionSystem);
            _cameraMovement.Initialize(_inputManager);
            _cameraRotation.Initialize(_inputManager);
            _cameraZoom.Initialize(_inputManager);
            // camera controller initialize after all other stuff
            _cameraController.Initialize(_cameraInputHandler, _cameraMovement, _cameraRotation, _cameraZoom);
        }
    }
}
