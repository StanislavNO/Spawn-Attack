using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class Stick : MonoBehaviour
    {
        [SerializeField] private Sprite _icon;
        [SerializeField] private string _label;
        [SerializeField] private int _price;
        [SerializeField] private bool _isPurchased;

        [SerializeField] private Ball _ball;
        [SerializeField] private Transform _shootPoint;

        protected void Shot()
        {
            Instantiate(_shootPoint, 
                _shootPoint.position, 
                Quaternion.identity);
        }
    }
}