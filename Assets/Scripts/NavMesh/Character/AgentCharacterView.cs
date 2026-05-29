using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class AgentCharacterView : MonoBehaviour
    {
        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

        [SerializeField] private AgentCharacter _character;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (_character.CurrentVelocity.magnitude > 0.05f)
                StrartRunning();
            else
                StopRunning();
        }

        private void StopRunning()
        {
            _animator.SetBool(IsRunningKey, false);
        }

        private void StrartRunning()
        {
            _animator.SetBool(IsRunningKey, true);
        }
    }
}
