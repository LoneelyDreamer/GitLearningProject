using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class RandomDirectionSelector : ITargeSelector
    {
        private float _min = -3f;
        private float _max = 3f;
        private Transform _randomTarget;


        public Transform SelectFrom(List<Transform> targets, Transform transformPosition)
        {
            _randomTarget = targets[0];
            _randomTarget.position = new Vector3(GetRandomFloat(), 0, GetRandomFloat());
            return _randomTarget;
        }

        private float GetRandomFloat()
        {
            return Random.Range(_min, _max + 1);
        }
    }
}
