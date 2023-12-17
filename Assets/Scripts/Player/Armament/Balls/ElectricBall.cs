using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class ElectricBall : Ball
    {
        public override int Attack()
        {
            return Damage;
        }
    }
}