using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.RayCast
{
    public class ExsplousenEffect : IRayCastEffect
    {
        private float _radius;
        private ShootEffect _shootEffect;
        public ExsplousenEffect(float radius, ShootEffect shootEffect)
        {
            _radius = radius;   
            _shootEffect = shootEffect;
        }

        public void Exsecute(Vector3 point, Collider collider)
        {
            Collider[] targets = Physics.OverlapSphere(point, _radius);

            foreach (Collider target in targets)
            {
                _shootEffect.Exsecute(target.transform.position, target);

                Debug.Log("Exsploid");
            }
        }
    }
}
