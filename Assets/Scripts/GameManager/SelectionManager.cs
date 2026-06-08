using System;
using TurnBased.PlayerView;
using UnityEngine;

namespace TurnBased.Units
{
    public class SelectionManager : MonoBehaviour
    {
        public event Action<ISelectable> OnUnitSelected;
        public event Action OnUnitDeselected;

        private ISelectable _currentSelectable;

        public void Select(ISelectable selectable)
        {
            _currentSelectable?.Deselect();
            _currentSelectable = selectable;
            _currentSelectable.Select();

            OnUnitSelected?.Invoke(_currentSelectable);
        }

        public void Deselect()
        {
            _currentSelectable?.Deselect();
            _currentSelectable = null;

            OnUnitDeselected?.Invoke();
        }

        public bool HasSelection() => _currentSelectable == null;
        public ISelectable CurrentSelection() => _currentSelectable;
    }
}
