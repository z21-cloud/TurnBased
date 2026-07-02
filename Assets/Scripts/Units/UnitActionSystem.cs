using TurnBased.Pathfinding;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.Units
{
    public class UnitActionSystem
    {
        private LevelGrid _levelGrid;
        private IActionable _currentUnit;

        public void Initialize(SelectionManager selectionManager, LevelGrid levelGrid)
        {
            selectionManager.OnUnitSelected += OnUnitSelected;
            selectionManager.OnUnitDeselected += OnUnitDeselected;

            _levelGrid = levelGrid;
        }

        private void OnUnitSelected(ISelectable selectable)
        {
            _currentUnit = selectable as IActionable;
        }

        private void OnUnitDeselected()
        {
            _currentUnit = null;
        }

        public void MoveUnit(Vector3 targetPosition)
        {
            if(_currentUnit == null || _levelGrid.IsFinalCoordsOccupied(targetPosition)) return;

            Vector3 unitStartPosition = _currentUnit.WorldPosition;
            _levelGrid.ClearSelectableAtGridPosition(unitStartPosition);
            
            Vector3 nodeCenter = _levelGrid.GetCenterNodePosition(targetPosition);
            _currentUnit?.ExecuteMove(nodeCenter);

            _levelGrid.SetSelectableAtGridPosition(_currentUnit, nodeCenter);
        }
    }
}
