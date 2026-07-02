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
        [SerializeField] private CameraInputHandler _cameraController;
        [SerializeField] private CameraMovement _cameraMovement;
        [SerializeField] private InputManager _inputManager;
        [SerializeField] private MouseVisual _cursorVisual;
        // [SerializeField] private UnitActionSystem _unitActionSystem;
        [SerializeField] private LevelGrid _levelGrid;
        [SerializeField] private List<UnitController> _units;

        private void Awake()
        {
            SelectionManager selectionManager = new();
            UnitActionSystem unitActionSystem = new();
            
            unitActionSystem.Initialize(selectionManager, _levelGrid);
            _cameraController.Initialize(_inputManager, selectionManager, unitActionSystem);
            _cursorVisual.Initialize(_cameraController);
            _cameraMovement.Initialize(_inputManager, _inputManager);

            foreach(var unit in _units)
            {
                unit.Initialize(_levelGrid.GetCenterNodePosition(unit.StartPosition));

                _levelGrid.RegisterUnit(unit, unit.WorldPosition);
            }
        }
    }
}
