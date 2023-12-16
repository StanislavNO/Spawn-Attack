using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Buyer : MonoBehaviour
    {
        [SerializeField] private UnityEvent<Ball> _productPurchased;
        [SerializeField] private Button _buyButton;
        [SerializeField] private Wallet _wallet;
        [SerializeField] private Ball _product;

        public void Buy()
        {
            if (_wallet.TryBuy(_product.Price))
            {
                _buyButton.enabled = false;
            }
        }
    }
}