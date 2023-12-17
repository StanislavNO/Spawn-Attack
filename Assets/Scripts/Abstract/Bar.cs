using System.Collections;
using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;
        [SerializeField] protected bool IsTemporary;

        protected float Speed = 0.5f;

        public void OnValueChanged(int value, int maxValue)
        {
            if (IsTemporary)
            {
                if(gameObject.active)
                    StartCoroutine(RenderDelay(value, maxValue));
            }
            else
                Slider.value = (float)value / maxValue;
        }

        private IEnumerator RenderDelay(int value, int maxValue)
        {
            float targetValue = (float)value / maxValue;

            while (Slider.value != targetValue)
            {
                Slider.value = Mathf.MoveTowards
                    (Slider.value,
                    (float)value / maxValue,
                    Time.deltaTime * Speed);

                yield return null;
            }
        }
    }
}