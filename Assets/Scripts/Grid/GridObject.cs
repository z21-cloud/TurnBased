using TurnBased.Units;
using UnityEngine;
using UnityEngine.Video;

namespace TurnBased.Pathfinding
{
    public class GridObject
    {
        private GridSystem _gridSystem;    
        private GridPosition _gridPosition;
        private IActionable _actionable;

        public GridObject(GridSystem gridSystem, GridPosition gridPosition)
        {
            _gridSystem = gridSystem;
            _gridPosition = gridPosition;
        }

        public override string ToString()
        {
            return _gridPosition.ToString(); // + "\n" + ((MonoBehaviour)_actionable).gameObject.name;
        }

        public void SetUnit(IActionable actionable)
        {
            // add check if node is occupied

            _actionable = actionable;
        }

        public IActionable GetUnit()
        {
            // add check if node is null

            return _actionable;
        }

        // clears grid object, needs when unit goes from old node to new. Clear old node
        public void ClearGridObject()
        {
            _actionable = null;
        }
    }
}
