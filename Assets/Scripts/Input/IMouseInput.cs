using UnityEngine;

namespace TurnBased.PlayerInput
{
    public interface IMouseInput
    {
        public Vector2 MousePosition { get; }
        public bool LeftMouseButton { get; }
        public bool RightMouseButton { get; }
    }
}
