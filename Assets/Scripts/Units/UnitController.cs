using TurnBased.Units;
using UnityEngine;

namespace TurnBased.Units
{
    public class UnitController : MonoBehaviour, IControllable
    {
        [SerializeField] private MonoBehaviour _moverBehaviour;

        private IMoveable _mover;

        private void Awake()
        {
            _mover = (IMoveable)_moverBehaviour;
        }

        public void Select()
        {

        }

        public void SetTargetPosition(Vector3 position)
        {
            _mover.SetDestination(position);
        }
    }
}
