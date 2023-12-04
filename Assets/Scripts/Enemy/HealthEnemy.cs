using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class HealthEnemy : Health
    {
        public override void OnTriggerEnter2D(Collider2D collision)
        {
            base.OnTriggerEnter2D(collision);
        }
    }
}