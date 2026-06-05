using UnityEngine;

namespace TurnBased.Units
{
    public class UnitMover : MonoBehaviour, IMoveable
    {
        [SerializeField] private float _speed = 5f;
        [SerializeField] private float _rotationSpeed = 5f;
        [SerializeField] private float _destinationThreshold = .1f;
        public bool HasReached { get; private set; }

        private Vector3 _targetPosition;

        public void SetDestination(Vector3 targetPosition)
        {
            _targetPosition = targetPosition;
        }

        private void Awake()
        {
            _targetPosition = transform.position;
        }

        void Update()
        {
            if (Vector3.Distance(transform.position, _targetPosition) < _destinationThreshold)
            {
                HasReached = true;
                return;
            }

            Vector3 direction = (_targetPosition - transform.position).normalized;
            transform.position += direction * Time.deltaTime * _speed;

            transform.forward = Vector3.Lerp(transform.forward, direction, _rotationSpeed * Time.deltaTime);

            HasReached = false;
        }
    }
}