using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _reward;
        [SerializeField] private Player _target;

        public Player Target => _target;

        public void TryGetReward()
        {
            if(_target.TryGetComponent(out Wallet wallet))
                wallet.SetMoney((uint)_reward);
        }
    }
}