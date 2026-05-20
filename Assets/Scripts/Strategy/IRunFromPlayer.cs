using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class IRunFromPlayer : IReactingOnPlayer
    {       
        public Transform React(Transform self, Transform player)
        {
            Vector3 direction = self.position + player.position;
            self.position = direction;
            return self;
        }
    }
}
