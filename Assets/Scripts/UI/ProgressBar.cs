﻿using System.Collections;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public class ProgressBar : Bar
    {
        [SerializeField] private EnemySpawner _spawner;

        private void Start()
        {
            ShowProgress();
        }

        public void ShowProgress()
        {
            OnValueChanged(_spawner.EnemyCounter, _spawner.MaxEnemy);
        }
    }
}