using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private int _reward;
        
        private Player _target;

        public Player Target => _target;

        public void Init(Player player)
        {
            _target = player;
        }

        public void TryGetReward()
        {
            if(_target.TryGetComponent(out Wallet wallet))
                wallet.SetMoney((uint)_reward);
        }
    }
}