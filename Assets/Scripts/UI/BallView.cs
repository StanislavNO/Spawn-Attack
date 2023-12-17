using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _buyButton;

        private Shop _shop;
        private TMP_Text _productDescription;
        private Ball _ball;

        public int PriceBall => _ball.Price;

        public void Init(TMP_Text description, Shop shop)
        {
            _productDescription = description;
            _shop = shop;
        }

        private void Awake()
        {
            _buyButton.onClick.AddListener(InformShop);
        }

        public void ShowDescription()
        {
            if (_productDescription != null)
                _productDescription.text = _ball.Label;
        }

        public void Render(Ball ball)
        {
            _ball = ball;

            _price.text = _ball.Price.ToString();
            _icon.sprite = _ball.Icon;
        }

        private void InformShop()
        {
            _shop?.TryToSell(_ball, _buyButton);
        }
    }
}