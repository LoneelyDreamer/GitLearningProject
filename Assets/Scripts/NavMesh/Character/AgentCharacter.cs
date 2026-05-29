using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.NavMesh
{
    public class AgentCharacter : MonoBehaviour
    {
        private NavMeshAgent _agent;

        private AgentMover _agentMover;
        private DiractionalRotator _diractionalRotator;

        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _moveSpeed;

        [SerializeField] private Transform _target;

        public Vector3 CurrentVelocity => _agentMover.CurrentVelocity;
        public Quaternion CurrentRotation => _diractionalRotator.CurrentRotation;

        private void Awake()
        {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;

            _agentMover = new AgentMover(_agent, _moveSpeed);
            _diractionalRotator = new DiractionalRotator(transform, _rotationSpeed);
        }

        private void Update()
        {         
            _diractionalRotator.Update(Time.deltaTime);
        }

        public void SetRotationDirection(Vector3 inputDirection) => _diractionalRotator.SetInputDirection(_agent.desiredVelocity);

        public void SetDestination(Vector3 destination) => _agentMover.SetDestination(destination);

        public void StopMove() => _agentMover.Stop();   
        public void ResumeMove() => _agentMover.Resume();   

        public bool TryGetPath(Vector3 targetPosition,NavMeshPath pathToTarget)
        =>NavMeshUtils.TryGetPath(_agent, targetPosition, pathToTarget);

    }
}
