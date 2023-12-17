using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class VictoryState : State
    {
        private const string WinTrigger = "Victory";

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _animator.SetTrigger(WinTrigger);
        }

        private void OnDisable()
        {
            _animator.StopPlayback();
        }
    }
}