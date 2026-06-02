using UnityEngine;

namespace TurnBased.Units
{
    public class UnitMover : MonoBehaviour, IMoveable
    {
        [SerializeField] private float speed = 5f;
        [SerializeField] private float destinationThreshold = .1f;
        public bool HasReached { get; private set; }

        private Vector3 _targetPosition;

        public void SetDestination(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        void Update()
        {
            if(Vector3.Distance(transform.position, _targetPosition) < destinationThreshold) return;

            Vector3 moveDirection = (_targetPosition - transform.position).normalized;
            transform.position += moveDirection * Time.deltaTime * speed; 
        }
    }
}