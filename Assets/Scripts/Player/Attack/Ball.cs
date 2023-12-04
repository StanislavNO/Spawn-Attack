using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ball : MonoBehaviour, IAttacker
    {
        [SerializeField] protected int Damage;

        private Rigidbody2D _rigidBody;

        protected void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        protected void FixedUpdate()
        {
            Move();
        }

        protected virtual void Move()
        {
            _rigidBody.AddForce(Vector2.left, ForceMode2D.Impulse);
        }

        public abstract int Attack();
    }
}