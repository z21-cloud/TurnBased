using TurnBased.Units;
using UnityEngine;

namespace TurnBased.Units
{
    public class UnitActionSystem : MonoBehaviour
    {
        private IActionable _currentUnit;

        public void Initialize(SelectionManager selectionManager)
        {
            selectionManager.OnUnitSelected += OnUnitSelected;
            selectionManager.OnUnitDeselected += OnUnitDeselected;
        }

        private void OnUnitSelected(ISelectable selectable)
        {
            _currentUnit = selectable as IActionable;
        }

        private void OnUnitDeselected()
        {
            _currentUnit = null;
        }

        public void MoveUnit(Vector3 position)
        {
            _currentUnit?.ExecuteMove(position);
        }
    }
}
