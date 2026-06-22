using UnityEngine;

namespace TurnBased.Pathfinding
{
    public struct GridPosition
    {
        public int X;
        public int Z;

        public GridPosition(int X, int Z)
        {
            this.X = X;
            this.Z = Z;
        }

        public override string ToString()
        {
            return $"X: {X}, Z: {Z}";
        }
    }
}
