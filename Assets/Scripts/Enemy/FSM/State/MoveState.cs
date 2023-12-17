using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Animator))]
    public class MoveState : State
    {
        private const string WalkTrigger = "Walk";

        [SerializeField] private float _speed;

        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private void OnEnable()
        {
            _animator.SetBool(WalkTrigger, true);
        }

        private void OnDisable()
        {
            _animator.SetBool(WalkTrigger, false);
        }

        private void Update()
        {
            transform.position = Vector2.MoveTowards(
                transform.position,
                Target.transform.position,
                _speed * Time.deltaTime);
        }
    }
}