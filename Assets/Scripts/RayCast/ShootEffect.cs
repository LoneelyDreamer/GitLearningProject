using UnityEditor.PackageManager;
using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class ShootEffect : IRayCastEffect
    {
        public void Exsecute(Vector3 point, Collider collider)
        {
            IDamajeble damajeble = collider.GetComponent<IDamajeble>();

            if (damajeble != null)
            {
                damajeble.TakeDamege();
            }
        }
    }
}
