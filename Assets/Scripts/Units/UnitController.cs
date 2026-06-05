using UnityEngine;

namespace TurnBased.Units
{
    public class UnitController : MonoBehaviour, IActionable, ISelectable
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
            if (!_mover.HasReached) _animator.SetBool("IsRunning", true);
            else _animator.SetBool("IsRunning", false);
        }

        public void ExecuteMove(Vector3 position)
        {
            _mover.SetDestination(position);
        }

        public void Select()
        {
            Debug.Log($"[UnitController]: Unit Selected: {gameObject.name}");
        }

        public void Deselect()
        {
            Debug.Log($"[UnitController]: Unit Deselected: {gameObject.name}");
        }
    }
}
