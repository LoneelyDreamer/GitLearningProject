using UnityEngine;

namespace Assets.Scripts.Strategy
{
    public class Deth : IReactingOnPlayer
    {

        public Transform React(Transform self, Transform player)
        {
            self.gameObject.SetActive(false);
            return self;
        }
    }
}
