using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Storm : Ball
    {
        public override int Attack()
        {
            return Damage;
        }
    }
}