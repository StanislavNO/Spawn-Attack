using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class Shop : MonoBehaviour
    {
        [SerializeField] private List<Ball> _balls;
        [SerializeField] private Player _player;
        [SerializeField] private BallView _template;
        [SerializeField] private GameObject _itemContainer;
        [SerializeField] private TMP_Text _productDescription;

        private void Awake()
        {
            foreach (var ball in _balls)
                AddStick(ball);
        }

        private void AddStick(Ball ball)
        {
            var view = Instantiate(_template, _itemContainer.transform);
            view.Init(_productDescription);

            view.Render(ball);
        }
    }
}