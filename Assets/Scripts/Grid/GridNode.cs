using UnityEngine;

namespace TurnBased.Pathfinding
{
    public struct GridNode
    {
        public int X;
        public int Z;

        public GridNode(int X, int Z)
        {
            this.X = X;
            this.Z = Z;
        }
    }
}
