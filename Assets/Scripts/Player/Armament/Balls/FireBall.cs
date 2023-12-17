using UnityEngine;

namespace Assets.Scripts
{
    public class FireBall : Ball
    {
        private float _counter;
        private int _countAttack;
        private int _maxAttackNumber = 2;

        private void Update()
        {
            _counter += Time.deltaTime;
        }

        public override int Attack()
        {
            int result = 0;

            _countAttack++;

            if (_countAttack > _maxAttackNumber)
            {
                result = Damage - (int)_counter;
            }
            else
                result = Damage;

            if (_countAttack == _maxAttackNumber)
            {
                Die();
            }

            return result;
        }

        private void Die()
        {
            gameObject.SetActive(false);
        }
    }
}