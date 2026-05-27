using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public interface IRayCastEffect
    {
        public void Exsecute(Vector3 point, Collider collider);
    }
}
