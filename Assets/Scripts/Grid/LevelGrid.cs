using TurnBased.Pathfinding;
using UnityEngine;

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
}
