using UnityEngine;

namespace Assets.Scripts.NavMesh
{
    public interface IDiractionalRotator
    {
        public Quaternion CurrrentRotation { get; }

        public void SetRotationDiraction(Vector3 inputDirection);
    }
}
