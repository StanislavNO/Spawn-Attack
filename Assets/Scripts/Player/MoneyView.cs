using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class MoneyView : MonoBehaviour
    {
        [SerializeField] private Wallet _wallet;
        [SerializeField] private TMP_Text _text;

        public void ShowMoney()
        {
            _text.text = _wallet.Money.ToString();
        }
    }
}