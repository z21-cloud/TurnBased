using UnityEngine;

namespace TurnBased.Units
{
    public interface IControllable
    {
        public void Select();
        public void SetTargetPosition(Vector3 position);
    }
}

