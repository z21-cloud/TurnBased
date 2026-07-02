using System.Collections.Generic;
using TurnBased.Pathfinding;
using TurnBased.Units;
using UnityEngine;

namespace TurnBased.Pathfinding
{
public class LevelGrid : MonoBehaviour
{
    [SerializeField] private int _height;
    [SerializeField] private int _width;
    [SerializeField] private int _cellSize;
    [SerializeField] private Transform _gridDebugTransform;

    private GridSystem _gridSystem;

    private void Awake()
    {
        _gridSystem = new GridSystem(_height, _width, _cellSize);
        _gridSystem.CreateDebugObject(_gridDebugTransform);
    }

    public void RegisterUnit(IActionable actionable, Vector3 startPosition)
    {
        SetSelectableAtGridPosition(actionable, startPosition);
    }

    public void SetSelectableAtGridPosition(IActionable actionable, Vector3 worldPosition)
    {
        GridPosition gridPosition = _gridSystem.GetGridPosition(worldPosition);
        GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
        gridObject.SetUnit(actionable);
    }

    public IActionable GetSelectableFromGridPosition(Vector3 worldPosition)
    {
        GridPosition gridPosition = _gridSystem.GetGridPosition(worldPosition);
        GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnit();
    }

    public void ClearSelectableAtGridPosition(Vector3 worldPosition)
    {
        GridPosition gridPosition = _gridSystem.GetGridPosition(worldPosition);
        GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
        gridObject.ClearGridObject();
    }

    public Vector3 GetCenterNodePosition(Vector3 worldPosition)
    {
        GridPosition gridPosition = _gridSystem.GetGridPosition(worldPosition);
        return _gridSystem.GetWorldPosition(gridPosition);
    }

    public bool IsFinalCoordsOccupied(Vector3 worldPosition)
    {
        GridPosition gridPosition = _gridSystem.GetGridPosition(worldPosition);
        GridObject gridObject = _gridSystem.GetGridObject(gridPosition);
        return gridObject.GetUnit() != null;
    }
}
}