using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(Rigidbody2D))]
    public abstract class Ball : MonoBehaviour, IAttacker
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _label;
        [SerializeField] private int _price;
        [SerializeField] private bool _isPurchased;

        [SerializeField] protected int Damage;

        private Rigidbody2D _rigidBody;

        public string Label => _label;
        public int Price => _price;
        public Sprite Icon => _icon;
        public bool IsPurchased => _isPurchased;

        protected void Awake()
        {
            _rigidBody = GetComponent<Rigidbody2D>();
        }

        protected void FixedUpdate()
        {
            Move();
        }

        public abstract int Attack();

        protected virtual void Move()
        {
            _rigidBody.AddForce(Vector2.left, ForceMode2D.Impulse);
        }
    }
}