using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Transition : MonoBehaviour
    {
        [SerializeField] private State _nextState;

        protected Player Target { get; private set; }

        public State TargetState => _nextState;
        public bool NeedTransit { get; protected set; }

        public void Init(Player target)
        {
            Target = target;
        }

        private void OnEnable()
        {
            NeedTransit = false;
        }
    }
}