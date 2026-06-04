using UnityEngine;

namespace TurnBased.PlayerView
{
    public interface IMouseWorldPosition
    {
        public Vector3 MouseWorldPosition { get; }
        public bool HasPosition { get; }
    }
}
