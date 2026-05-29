using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class CharacterView : MonoBehaviour
    {
        private readonly int IsRunningKey = Animator.StringToHash("IsRunning");

        [SerializeField] private Charecter _character;
        [SerializeField] private Animator _animator;

        private void Update()
        {
            if (_character.CurrrentVelocity.magnitude > 0.05f)
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
