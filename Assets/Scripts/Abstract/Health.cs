﻿using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public abstract class Health : MonoBehaviour
    {
        [SerializeField] protected UnityEvent LivesAreOver;
        [SerializeField] protected UnityEvent HealthChanged;

        [SerializeField] protected int Point;

        public int MaxPoint { get; private set; }
        public int LivePoint { get; private set; }

        private void Awake()
        {
            MaxPoint = Point;
            LivePoint = Point;
        }

        public virtual void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IAttacker attacker))
                SetDamage(attacker.Attack());
        }

        public virtual void SetDamage(int damage)
        {
            if (damage > uint.MinValue)
                LivePoint -= damage;

            if (LivePoint <= uint.MinValue)
                LivesAreOver.Invoke();

            HealthChanged.Invoke();
        }
    }
}