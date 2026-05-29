
using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public interface IDiractionalMoveble
    {
        public Vector3 CurrrentVelocity { get; }
        public void SetMovementDirection(Vector3 inputDirection);
    }
}
