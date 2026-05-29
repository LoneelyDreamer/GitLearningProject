using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    internal class PlayerCharacterController : Controller
    {
        private Charecter _charecter;
        public PlayerCharacterController(Charecter charecter)
        {
            _charecter = charecter;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _charecter.SetMovementDirection(inputDirection);
            _charecter.SetRotationDiraction(inputDirection);
        }
    }
}
