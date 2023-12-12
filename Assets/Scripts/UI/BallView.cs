using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class BallView : MonoBehaviour
    {
        [SerializeField] private TMP_Text _price;
        [SerializeField] private Image _icon;
        [SerializeField] private Button _buyButton;

        private TMP_Text _productDescription;
        private Ball _ball;

        public void Init(TMP_Text description)
        {
            _productDescription = description;
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
    }
}