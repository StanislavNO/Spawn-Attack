using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public class CurrentBallViewChanger : MonoBehaviour
    {
        [SerializeField] private Image _image;
        [SerializeField] private Stick _stick;

        public void ChangeImage()
        {
            if (_stick.CurrentBall != null)
                _image.sprite = _stick.CurrentBall.Icon;
        }
    }
}