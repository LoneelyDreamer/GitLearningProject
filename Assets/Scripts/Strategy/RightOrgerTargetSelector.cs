using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class RightOrgerTargetSelector : ITargeSelector
    {
        public Transform SelectFrom(List<Transform> targets, Transform transformPosition)
        {
            Transform target = targets[0];
            targets.Remove(target);
            targets.Add(target);
            return target;
        }
    }
}
