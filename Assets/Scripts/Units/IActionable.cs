using UnityEngine;

namespace TurnBased.Units
{
    public interface IActionable
    {
        public Vector3 WorldPosition { get; }
        public void ExecuteMove(Vector3 position);
    }
}
