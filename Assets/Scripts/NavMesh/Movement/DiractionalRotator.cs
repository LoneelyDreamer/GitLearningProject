
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class DiractionalRotator
    {
        private Transform _transform;

        private float _rotationSpeed;

        private Vector3 _currentDirection;

        public DiractionalRotator(Transform transform, float rotationalSpeed)
        {
            _transform = transform;
            _rotationSpeed = rotationalSpeed;
        }

        public Quaternion CurrentRotation => _transform.rotation;   

        public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

        public void Update(float deltaTime)
        {
            if(_currentDirection.magnitude < 0.05f)
                return;

            Quaternion lookRotation = Quaternion.LookRotation(_currentDirection.normalized);

            float step = _rotationSpeed * deltaTime;

            _transform.rotation = Quaternion.RotateTowards(_transform.rotation, lookRotation, step);
        }
    }
}
