﻿using UnityEngine.UI;
using UnityEngine;

namespace Assets.Scripts
{
    public abstract class Bar : MonoBehaviour
    {
        [SerializeField] protected Slider Slider;

        public void OnValueChanged(int value, int maxValue)
        {
            Slider.value = (float)value / maxValue;
        }
    }
}