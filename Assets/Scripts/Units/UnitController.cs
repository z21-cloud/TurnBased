using UnityEngine;

namespace TurnBased.Units
{
    public class UnitController : MonoBehaviour, IControllable
    {
        [SerializeField] private MonoBehaviour _moverBehaviour;
        [SerializeField] private Animator _animator;

        private IMoveable _mover;

        private void Awake()
        {
            _mover = (IMoveable)_moverBehaviour;
        }

        private void Update()
        {
            if(!_mover.HasReached) _animator.SetBool("IsRunning", true);
            else _animator.SetBool("IsRunning", false);
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
