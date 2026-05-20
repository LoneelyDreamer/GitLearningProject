using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public interface ITargeSelector
    {
        public Transform SelectFrom(List<Transform> targets, Transform spawnPosition);
    }
}
