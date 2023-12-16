using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class Stick : MonoBehaviour
    {
        [SerializeField] private UnityEvent _currentBallChanged;
        [SerializeField] private Transform _shootPoint;

        private List<Ball> _balls = new();
        private int _currentBallIndex;
        private Animator _animator;
        private bool _canAttack;

        public Ball CurrentBall { get; private set; }

        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _canAttack = true;
        }

        public void AddBall(Ball ball)
        {
            _balls.Add(ball);
            CurrentBall = ball;
            _currentBallChanged?.Invoke();
        }

        public void Attack()
        {
            if (Time.timeScale != 0)
                StartCoroutine(ShotDelay());
        }

        public void NextBall(bool isUp)
        {
            int minNextBallNumber = 2;
            int minIndex = 0;
            int maxIndex = _balls.Count - 1;

            if (_balls.Count < minNextBallNumber)
                return;

            if (isUp)
            {
                if (_currentBallIndex < maxIndex)
                    _currentBallIndex++;
                else
                    _currentBallIndex -= _currentBallIndex;
            }
            else
            {
                if (_currentBallIndex == minIndex)
                    _currentBallIndex = maxIndex;
                else
                    _currentBallIndex--;
            }

            CurrentBall = _balls[_currentBallIndex];
            _currentBallChanged?.Invoke();
        }

        private void Shot()
        {
            Instantiate(CurrentBall,
                _shootPoint.position,
                Quaternion.identity);
        }

        private IEnumerator ShotDelay()
        {
            WaitForSecondsRealtime delay = new(0.4f);

            if (CurrentBall == null)
                yield break;

            if (_canAttack)
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