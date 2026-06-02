using UnityEngine;

namespace TurnBased.Units
{
    public interface IMoveable
    {
        public bool HasReached { get; }

        public void SetDestination(Vector3 targetPosition);
    }
}
