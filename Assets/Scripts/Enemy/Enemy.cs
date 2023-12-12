using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _reward;
        [SerializeField] private Health _health;
        
        private Player _target;

        public Player Target => _target;

        public void Init(Player player)
        {
            _target = player;
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IAttacker attacker))
                _health.SetDamage(attacker.Attack());
        }

        public void Dying()
        {
            TryGetReward();
            Destroy(gameObject);
            gameObject.SetActive(false);
        }

        private void TryGetReward()
        {
            if(_target.TryGetComponent(out Wallet wallet))
                wallet.SetMoney((uint)_reward);
        }
    }
}