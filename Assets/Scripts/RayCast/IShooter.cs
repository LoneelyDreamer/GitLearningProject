using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public interface IShooter
    {
        public void Shoot(Vector3 origin, Vector3 direction);
    }
}
