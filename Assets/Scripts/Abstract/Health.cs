using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private UnityEvent _livesAreOver;
        [SerializeField] private UnityEvent _healthChanged;

        [SerializeField] private int _point;

        private uint _minPoint = uint.MinValue;

        public int MaxPoint { get; private set; }
        public int LivePoint { get; private set; }

        private void Awake()
        {
            MaxPoint = _point;
            LivePoint = _point;
        }

        public virtual void SetDamage(int damage)
        {
            if (damage > _minPoint)
                LivePoint -= damage;

            if (LivePoint <= _minPoint)
                _livesAreOver.Invoke();

            _healthChanged.Invoke();
        }
    }
}