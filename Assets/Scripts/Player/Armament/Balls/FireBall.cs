using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class FireBall : Ball
    {
        private float _counter;
        private int _countAttack;
        private int _maxAttackNumber = 2;
        private float _minScale = 2;

        private void Update()
        {
            _counter += Time.deltaTime;
        }

        public override int Attack()
        {
            _countAttack++;

            if (_countAttack > _maxAttackNumber)
            {
                transform.localScale /= _minScale;
            }

            if (_countAttack == _maxAttackNumber)
            {
                Die();
            }

            return Damage + (int)_counter;
        }

        public void Die()
        {
            Destroy(gameObject);
        }
    }
}