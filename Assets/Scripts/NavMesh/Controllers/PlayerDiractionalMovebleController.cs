using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public class PlayerDiractionalMovebleController : Controller
    {
        private IDiractionalMoveble _diractionalMoveble;

        public PlayerDiractionalMovebleController(IDiractionalMoveble diractionalMoveble)
        {
            _diractionalMoveble = diractionalMoveble;
        }

        protected override void UpdateLogic(float deltaTime)
        {
            Vector3 inputDirection = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));

            _diractionalMoveble.SetMovementDirection(inputDirection);
        }
    }
}
