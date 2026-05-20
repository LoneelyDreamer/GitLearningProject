using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class IChasingPlayer : IReactingOnPlayer
    {       
        public Transform React(Transform self, Transform player)
        {
            return player;
        }
    }
}
