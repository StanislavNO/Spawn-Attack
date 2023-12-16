using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class IceBall : Ball
    {
        public override int Attack()
        {
            return Damage;        
        }
    }
}