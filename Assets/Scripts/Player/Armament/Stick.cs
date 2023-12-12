using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class Stick : MonoBehaviour
    {
        [SerializeField] private Ball _ball;
        [SerializeField] private Transform _shootPoint;

        private Animator _animator;
        private bool _canAttack;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _canAttack = true;
        }

        protected void Update()
        {
            if(Input.GetButtonDown("Fire1"))
            {
                StartCoroutine(ShotDelay());
            }
        }

        protected void Shot()
        {
            Instantiate(_ball, 
                _shootPoint.position, 
                Quaternion.identity);
        }

        private IEnumerator ShotDelay()
        {
            WaitForSecondsRealtime delay = new(0.4f);

            if(_canAttack) 
            {
                _canAttack = false;
                _animator.SetTrigger("Attack1");
                yield return delay;
                Shot();
                _canAttack = true;
            }
        }
    }
}