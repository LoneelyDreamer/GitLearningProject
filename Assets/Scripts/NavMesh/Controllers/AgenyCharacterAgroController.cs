using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Assets.Scripts.NavMesh
{
    public class AgenyCharacterAgroController : Controller
    {
        private AgentCharacter _character;

        private Transform _target;

        private float _agroRange;
        private float _minDistanceToTarget;

        private float _idleTimer;
        private float _timeRorIdle;

        private NavMeshPath _pathToTarget = new NavMeshPath();

        public AgenyCharacterAgroController(AgentCharacter character,
            Transform target,
            float agroRange,
            float minDistanceToTarget,
            float timeRorIdle)
        {
            _character = character;
            _target = target;
            _agroRange = agroRange;
            _minDistanceToTarget = minDistanceToTarget;
            _timeRorIdle = timeRorIdle;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            _idleTimer -= Time.deltaTime;

            _character.SetRotationDirection(_character.CurrentVelocity);

            if (_character.TryGetPath(_target.position, _pathToTarget))
            {
                float distanceToTarget = NavMeshUtils.GetPathLenght(_pathToTarget);

                if (IsTargetRiched(distanceToTarget))
                    _idleTimer = _timeRorIdle;


                if (InAgroRange(distanceToTarget) && IdleTimerIsUp())
                {
                    _character.ResumeMove();
                    _character.SetDestination(_target.position);
                    return;
                }
            }

            _character.StopMove();
        }

        private bool IsTargetRiched(float distanceToTarget) => distanceToTarget <= _minDistanceToTarget;

        private bool InAgroRange(float distanceToTarget) => distanceToTarget <= _agroRange;

        private bool IdleTimerIsUp() => _idleTimer <= 0;
    }
}
