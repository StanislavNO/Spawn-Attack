using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private UnityEvent _moneyChange;
        [SerializeField] private uint _startMoney;

        public uint Money { get; private set; }

        private void Awake()
        {
            Money = _startMoney;
        }

        public void SetMoney(uint money)
        {
            Money += money;
            _moneyChange.Invoke();
        }

        public bool TryBuy(int price)
        {
            if (Money >= price)
            {
                Money -= (uint)price;
                _moneyChange.Invoke();
                return true;
            }

            return false;
        }
    }
}