using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class Charecter : MonoBehaviour, IDiractionalMoveble, IDiractionalRotator
    {
        private DiractionalRotator _diractionalRotator;
        private DirectionalMover _directionalMover;

        [SerializeField] private float _movementSpeed;
        [SerializeField] private float _rotationSpeed;

        public Vector3 CurrrentVelocity => _directionalMover.CurrentVelocity;
        public Quaternion CurrrentRotation => _diractionalRotator.CurrentRotation;

        private void Awake()
        {
            _diractionalRotator = new DiractionalRotator(transform, _rotationSpeed);
            _directionalMover = new DirectionalMover(GetComponent<CharacterController>(),_movementSpeed);
        }

        private void Update()
        {
            _directionalMover.Update(Time.deltaTime);
            _diractionalRotator.Update(Time.deltaTime);
        }

        public void SetRotationDiraction(Vector3 inputDirection)=> _diractionalRotator.SetInputDirection(inputDirection);

        public void SetMovementDirection(Vector3 inputDirection) => _directionalMover.SetInputDirection(inputDirection);


     
    }
}