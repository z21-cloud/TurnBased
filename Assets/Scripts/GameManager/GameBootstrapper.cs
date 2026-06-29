using System.Collections.Generic;
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
        // [SerializeField] private UnitActionSystem _unitActionSystem;
        [SerializeField] private LevelGrid _levelGrid;
        [SerializeField] private List<UnitController> _units;

        private void Awake()
        {
            SelectionManager selectionManager = new SelectionManager();
            UnitActionSystem unitActionSystem = new UnitActionSystem();
            
            unitActionSystem.Initialize(selectionManager, _levelGrid);
            _cameraController.Initialize(_inputManager, selectionManager, unitActionSystem);
            _cursorVisual.Initialize(_cameraController);

            foreach(var unit in _units)
            {
                unit.Initialize(_levelGrid.GetCenterNodePosition(unit.StartPosition));

                _levelGrid.RegisterUnit(unit, unit.WorldPosition);
            }
        }
    }
}
