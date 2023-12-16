using UnityEngine;

namespace Assets.Scripts
{
    public class Menu : MonoBehaviour
    {
        private float _stop = 0;

        private void Awake()
        {
            Time.timeScale = _stop;
        }
    }
}