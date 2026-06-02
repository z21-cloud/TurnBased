using UnityEngine;

namespace TurnBased.Tests
{
    public class MoveCalculator
    {
        public Vector3 MoveTowards(Vector3 current, Vector3 target, float speed)
        {
            return Vector3.MoveTowards(current, target, speed);
        }
    }
}

