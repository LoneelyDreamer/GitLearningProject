using Assets.Scripts.RayCast;
using UnityEngine;

public class ExplosionForceEffect : IRayCastEffect
{
    private float _radius;
    private float _force;

    public ExplosionForceEffect(float radius, float force)
    {
        _radius = radius;
        _force = force;
    }

    public void Exsecute(Vector3 hitPoint, Collider hitCollider)
    {
        // Находим все объекты в радиусе взрыва
        Collider[] targets = Physics.OverlapSphere(hitPoint, _radius);
        int affectedObjects = 0;

        foreach (Collider target in targets)
        {
            // Проверяем наличие Rigidbody для физического воздействия
            Rigidbody rb = target.GetComponent<Rigidbody>();
            if (rb != null)
            {
                // Добавляем силу взрыва
                rb.AddExplosionForce(_force, hitPoint, _radius, 0.5f, ForceMode.Impulse);
                affectedObjects++;
                Debug.Log($"Explosion force applied to: {target.name}");
            }

            // Дополнительно: проверяем интерфейс IExplosiveForce
            IExplosiveForce explosiveForce = target.GetComponent<IExplosiveForce>();
            if (explosiveForce != null)
            {
                explosiveForce.ApplyExplosionForce(hitPoint, _radius, _force);
            }
        }

        // Визуальный эффект (опционально)
        Debug.Log($"Explosion at {hitPoint} with radius {_radius}, force {_force}, affected {affectedObjects} objects");

        // Можно добавить Particle System для визуального эффекта взрыва
        CreateExplosionEffect(hitPoint);
    }

    private void CreateExplosionEffect(Vector3 position)
    {
        // Здесь можно добавить визуальный эффект взрыва
        // Например: Instantiate(prefabExplosion, position, Quaternion.identity);
        Debug.Log($"Visual explosion effect at {position}");
    }
}
