using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class AceBall : Ball
    {
        public override int Attack()
        {
            return Damage;        
        }
    }
}