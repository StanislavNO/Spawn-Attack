using System.Collections;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private AnimationClip _animationDie;
        [SerializeField] private UnityEvent PlayerDied;

        public void Die()
        {
            StartCoroutine(DelayAndDie());
        }

        private IEnumerator DelayAndDie()
        {
            WaitForSecondsRealtime delay = new(_animationDie.length);

            yield return delay;

            PlayerDied.Invoke();
        }
    }
}