using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public interface IReactingOnPlayer
    {
        public Transform React(Transform self, Transform player);
    }
}
