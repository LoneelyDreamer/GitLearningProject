
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class PlayerDiractionalRotatorController : Controller
    {
        private IDiractionalRotator _diractionalRotator;

        public PlayerDiractionalRotatorController(IDiractionalRotator diractionalRotator)
        {
            _diractionalRotator = diractionalRotator;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _diractionalRotator.SetRotationDiraction(inputDirection);
        }
    }
}
