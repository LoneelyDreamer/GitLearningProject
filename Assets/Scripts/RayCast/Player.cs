using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class Player : MonoBehaviour
    {
        private float _radius = 4f;
        private float _forse = 8f;
        private IShooter _shootShooter;    
        private IShooter _dragShooter;    
        private void Awake()
        {
           // _shootShooter = new RayShooter(new ExsplousenEffect(_radius, new ShootEffect()));
            _shootShooter = new RayShooter(new ExplosionForceEffect(_radius, _forse));

            _dragShooter = new RayShooter(new DragEffect());
        }

       

        private void Update()
        {
            if (Camera.main == null) return; 

            Ray ray = CreateRay();

            if (Input.GetMouseButtonDown(1))
            {
                _shootShooter.Shoot(ray.origin, ray.direction);
            }

            if (Input.GetMouseButton(0))
            {
                _dragShooter.Shoot(ray.origin, ray.direction);
            }
        }

        private Ray CreateRay()
        {
            return Camera.main.ScreenPointToRay(Input.mousePosition);
        }
    }
}
