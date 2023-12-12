using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class FireBall : Ball
    {
        private float _counter;

        private void Update()
        {
            _counter += Time.deltaTime;
        }

        public override int Attack()
        {
            return Damage + (int)_counter;
        }
    }
}