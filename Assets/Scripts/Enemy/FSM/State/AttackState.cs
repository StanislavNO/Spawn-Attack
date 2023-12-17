using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class AttackState : State
    {
        private const string AttackTrigger = "Attack";

        [SerializeField] private int _damage;
        [SerializeField] private float _delay;
        [SerializeField] private float _lastAttackTime;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            Attack(Target);
            _animator.SetTrigger(AttackTrigger);
        }

        private void Update()
        {
            if (_lastAttackTime <= 0)
            {
                Attack(Target);
                _lastAttackTime = _delay;
            }

            _lastAttackTime -= Time.deltaTime;
        }

        public void Attack(Player player)
        {
            if (player.TryGetComponent(out Health health))
                health.SetDamage(_damage);
        }
    }
}