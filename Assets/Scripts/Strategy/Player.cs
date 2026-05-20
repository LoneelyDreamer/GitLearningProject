using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float _speed;
        [SerializeField] private float _rotationSpeed;

        [SerializeField] private CharacterController _characterController;

        private float _deadZone = 0.1f;

        private void Update()
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));

            if(input.magnitude <= _deadZone)
                return;

            _characterController.Move(input.normalized * _speed * Time.deltaTime);
            ProcessRotateTo(input.normalized);
        }

        private void ProcessRotateTo(Vector3 direction)
        {
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            float step = _rotationSpeed * Time.deltaTime;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, lookRotation, step);
        }

    }
}


