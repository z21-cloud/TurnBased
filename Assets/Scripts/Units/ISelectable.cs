using UnityEngine;

namespace TurnBased.Units
{
    public interface ISelectable
    {
        public void Select();
        public void Deselect();
    }
}
