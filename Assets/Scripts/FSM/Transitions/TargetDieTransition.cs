using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class TargetDieTransition : Transition
    {
        private void Update()
        {
            if (Target == null)
                NeedTransit = true;
        }
    }
}