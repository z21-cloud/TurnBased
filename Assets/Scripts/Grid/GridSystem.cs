using System;
using UnityEngine;

namespace TurnBased.Pathfinding
{
    public class GridSystem
    {
        private int _height;
        private int _width;
        private float _cellSize;
        private GridNode[,] _nodes;

        // Initializitaion;
        public GridSystem(int height, int width, float cellSize)
        {
            _height = height;
            _width = width;
            _cellSize = cellSize;
            _nodes = new GridNode[height, width];

            Debug.Log($"[GridSystem] Initialized matrix - {_height}:{_width}");
        }

        public Vector3 GetWorldPosition(int x, int z)
        {
            return new Vector3(x, 0, z) * _cellSize;
        }

        public GridNode GetGridNode(Vector3 worldPosition)
        {
            return new GridNode(
                Mathf.FloorToInt(worldPosition.x / _cellSize),
                Mathf.FloorToInt(worldPosition.z / _cellSize)
            );
        }
    }
}
