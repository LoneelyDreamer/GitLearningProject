using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class RayShooter : IShooter
    {
        private IRayCastEffect _rayCastEffect;

        public RayShooter(IRayCastEffect rayCastEffect) 
        {
            _rayCastEffect = rayCastEffect;
        }

        public void Shoot(Vector3 origin, Vector3 direction)
        {
            Ray ray = new Ray(origin, direction);

            if (Physics.Raycast(ray, out RaycastHit hitInfo))
            {
                _rayCastEffect.Exsecute(hitInfo.point, hitInfo.collider);
            }
        }

    }
}
