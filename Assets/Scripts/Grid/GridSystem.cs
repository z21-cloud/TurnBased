using System;
using UnityEngine;

namespace TurnBased.Pathfinding
{
    public class GridSystem
    {
        private int _height;
        private int _width;
        private float _cellSize;
        private GridObject[,] _nodes;

        // Initializitaion;
        public GridSystem(int height, int width, float cellSize)
        {
            _height = height;
            _width = width;
            _cellSize = cellSize;
            _nodes = new GridObject[height, width];

            for(int x = 0; x < _height; x++)
            {
                for(int z = 0; z < _width; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    _nodes[x, z] = new GridObject(this, gridPosition);
                }
            }
        }

        public Vector3 GetWorldPosition(GridPosition gridPosition)
        {
            return new Vector3(gridPosition.X, 0, gridPosition.Z) * _cellSize;
        }

        public GridPosition GetGridNode(Vector3 worldPosition)
        {
            return new GridPosition(
                Mathf.RoundToInt(worldPosition.x / _cellSize),
                Mathf.RoundToInt(worldPosition.z / _cellSize)
            );
        }

        public void CreateDebugObject(Transform debugObject)
        {
            for(int x = 0; x < _height; x++)
            {
                for(int z = 0; z < _width; z++)
                {
                    GridPosition gridPosition = new GridPosition(x, z);
                    Transform debugTransofrm = GameObject.Instantiate(debugObject, GetWorldPosition(gridPosition), Quaternion.identity);
                    GridDebugObject gridDebugObject = debugTransofrm.GetComponent<GridDebugObject>();
                    gridDebugObject.SetGridObject(GetGridObject(gridPosition));
                }
            }
        }

        public GridObject GetGridObject(GridPosition gridPosition)
        {
            return _nodes[gridPosition.X, gridPosition.Z];
        }
    }
}
