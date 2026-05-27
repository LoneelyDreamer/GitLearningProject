using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class Box : MonoBehaviour, IDamajeble, IDragable, IExplosiveForce
    {
        private Rigidbody _rigidbody;

        private void Awake()
        {
            // Добавляем Rigidbody для физики
            _rigidbody = GetComponent<Rigidbody>();
            if (_rigidbody == null)
            {
                _rigidbody = gameObject.AddComponent<Rigidbody>();
            }
        }
        public void Drag(Vector3 targetPoint)
        {
            transform.position = new Vector3(targetPoint.x, transform.position.y, targetPoint.z);
        }
        public void TakeDamege()
        {
            Destroy(gameObject);
        }

        public void ApplyExplosionForce(Vector3 explosionPoint, float radius, float force)
        {
            if (_rigidbody != null)
            {
                _rigidbody.isKinematic = false;

                _rigidbody.AddExplosionForce(force, explosionPoint, radius, 0.5f, ForceMode.Impulse);
                Debug.Log($"Explosion force applied to {gameObject.name}, Force: {force}");
            }
        }
    }
}