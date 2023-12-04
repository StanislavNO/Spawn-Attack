using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Enemy))]
    public class EnemyStateMachine : MonoBehaviour
    {
        [SerializeField] private State _startState;

        private Player _target;
        public State _currentState { get; private set; }

        private void Awake()
        {
            _target = GetComponent<Enemy>().Target;
            Reboot(_startState);
        }

        private void Update()
        {
            if (_currentState == null)
                return;

            var nextState = _currentState.GetNextState();

            if (nextState != null)
                Transit(nextState);
        }

        private void Reboot(State startState)
        {
            _currentState = startState;
            _currentState?.Enter(_target);
        }

        private void Transit(State nextState)
        {
            if (nextState != null)
                _currentState.Exit();

            _currentState = nextState;

            if (_currentState != null)
                _currentState.Enter(_target);
        }
    }
}