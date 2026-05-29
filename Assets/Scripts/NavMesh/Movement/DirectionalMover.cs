using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class DirectionalMover
    {
        private CharacterController _charecterController;

        private float _movementSpeed;

        private Vector3 _currentDirection;

        public DirectionalMover(CharacterController charecterController, float movementSpeed)
        {
            _charecterController = charecterController;
            _movementSpeed = movementSpeed;
        }

        public Vector3 CurrentVelocity { get; private set; }

        public void SetInputDirection(Vector3 direction) => _currentDirection = direction;

        public void Update(float deltaTime)
        {
            CurrentVelocity = _currentDirection.normalized * _movementSpeed;
            _charecterController.Move(CurrentVelocity * deltaTime);
        }
    }
}
