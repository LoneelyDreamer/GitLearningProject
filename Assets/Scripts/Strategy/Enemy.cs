using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        private float _minDistanseToTarget = 0.02f;

        [SerializeField] private CharacterController _characterController;

        private List<Transform> _targets;
        private Transform _target;
        private bool _isSeengPlayer = false;
        private ITargeSelector _selector;
        private IReactingOnPlayer _reactor;
        private Transform _player;

        public void Initialize(ITargeSelector targeSelector, IReactingOnPlayer reactingOnPlayer, List<Transform> targets)
        {
            _reactor = reactingOnPlayer;
            _targets = targets;
            SetTargetSelector(targeSelector);
        }

        public void SetTargetSelector(ITargeSelector targeSelector)
        {
            _selector = targeSelector;
            UpdateTarget();
        }



        private void Update()
        {
            Vector3 direction = GetDirectionTo(_target);

            if (_isSeengPlayer)
            {
                ReactOnPlayer();

            }

            if (direction.magnitude <= _minDistanseToTarget)
            {
                UpdateTarget();
                return;
            }

            Vector3 normalizedDirection = direction.normalized;

            ProssesMoveTo(normalizedDirection);
            ProcessRotateTo(normalizedDirection);

        }

        private void ReactOnPlayer() => _target = _reactor.React(transform, _player);


        private Vector3 GetDirectionTo(Transform target) => target.position - transform.position;

        private void ProcessRotateTo(Vector3 direction)
        {
            Vector3 xzDirection = new Vector3(direction.x, 0, direction.z);

            Quaternion lookRotation = Quaternion.LookRotation(xzDirection);
            float step = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }

        private void ProssesMoveTo(Vector3 direction)
        {
            _characterController.Move(direction * _speed * Time.deltaTime);
        }

        private void UpdateTarget() => _target = _selector.SelectFrom(_targets, transform);

        private void OnTriggerEnter(Collider other)
        {
            _isSeengPlayer = true;
            _player = other.transform;
        }

        private void OnTriggerExit(Collider other)
        {
            _isSeengPlayer = false;
        }
    }
}
