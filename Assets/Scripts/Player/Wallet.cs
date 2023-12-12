using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class Wallet : MonoBehaviour
    {
        [SerializeField] private UnityEvent _moneyChange;

        public uint Money { get; private set; }

        public void SetMoney(uint money)
        {
            Money += money;
            _moneyChange.Invoke();
        }

        public bool GetMoney(int price)
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