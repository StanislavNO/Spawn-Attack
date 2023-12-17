using UnityEngine;

namespace Assets.Scripts
{
    public class DistanceTransition : Transition
    {
        [SerializeField] private float _distance;
        [SerializeField] private float _steep;

        private void Start()
        {
            _distance += Random.Range(-_steep, _steep);
        }

        private void Update()
        {
            if (Vector2.Distance(
            transform.position, Target.transform.position) < _distance)
                NeedTransit = true;
        }
    }
}