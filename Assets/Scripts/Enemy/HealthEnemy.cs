using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Collider2D))]
    public class HealthEnemy : Health
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent(out IAttacker attacker))
                SetDamage(attacker.Attack());
        }
    }
}