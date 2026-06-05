using System;
using TurnBased.PlayerView;
using UnityEngine;

public class SelectionManager : MonoBehaviour
{
    public event Action<ISelectable> OnUnitSelected;
    public event Action OnUnitDeselected;

    private ISelectable _currentSelected;
    private IMouseWorldPosition _mouseWorldPosition;

    public void Initialize(IMouseWorldPosition mouseWorldPosition)
    {
        _mouseWorldPosition = mouseWorldPosition;    
    }

    public void Select(ISelectable selectable)
    {
        _currentSelected?.Deselect();
        _currentSelected = selectable;
        _currentSelected.Select();

        OnUnitSelected?.Invoke(_currentSelected);
    }

    public void Deselect()
    {
        _currentSelected?.Deselect();
        _currentSelected = null;

        OnUnitDeselected?.Invoke();
    }

    public bool HasSelection() => _currentSelected != null;
    public ISelectable Current => _currentSelected;
}
