using UnityEngine;

namespace TurnBased.Units
{
    public class UnitController : MonoBehaviour, IActionable, ISelectable
    {
        [SerializeField] private MonoBehaviour _moverBehaviour;
        [SerializeField] private Animator _animator;
        [SerializeField] private UnitVisual _unitVisual;

        private IMoveable _mover;

        public Vector3 WorldPosition { get; }

        private void Awake()
        {
            _mover = (IMoveable)_moverBehaviour;
        }

        private void Update()
        {
            if (!_mover.HasReached) _animator.SetBool("IsRunning", true);
            else _animator.SetBool("IsRunning", false);
        }

        public void ExecuteMove(Vector3 targetPosition)
        {
            _mover.SetDestination(targetPosition);
        }

        public void Select()
        {
            Debug.Log($"[UnitController] {gameObject.name} - has selected");
            _unitVisual.ShowSelection();
        }

        public void Deselect()
        {
            Debug.Log($"[UnitController] {gameObject.name} - has deselected");
            _unitVisual.HideSelection();
        }
    }
}
