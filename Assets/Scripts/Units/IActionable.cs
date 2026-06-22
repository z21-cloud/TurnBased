using UnityEngine;

namespace TurnBased.Units
{
    public interface IActionable
    {
        public void ExecuteMove(Vector3 position);
    }
}
