using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Wallet : MonoBehaviour
    {
        public uint Money { get; private set; }

        public void SetMoney(uint money)
        {
            Money += money;
        }

        public bool GetMoney(int price)
        {
            if (Money >= price)
            {
                Money -= (uint)price;
                return true;
            }

            return false;
        }
    }
}