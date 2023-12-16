using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Ball> _balls;
        [SerializeField] private Player _player;
        [SerializeField] private Stick _stick;
        [SerializeField] private BallView _ballView;
        [SerializeField] private GameObject _itemContainer;
        [SerializeField] private TMP_Text _productDescription;
        [SerializeField] private AudioSource _audioSource;

        private void Awake()
        {
            foreach (var ball in _balls)
                CreateBall(ball);

            gameObject.SetActive(false);
        }

        public void TryToSell(Ball ball, Button buyButton)
        {
            if (_player.GetComponent<Wallet>().TryBuy(ball.Price))
            {
                buyButton.enabled = false;
                _audioSource.Play();

                _stick.AddBall(ball);
            }
        }

        private void CreateBall(Ball ball)
        {
            var view = Instantiate(_ballView, _itemContainer.transform);

            view.Init(_productDescription, this);
            view.Render(ball);
        }
    }
}