﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private UnityEvent _allEnemySpawned;
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Player _player;

        private Wave _currentWave;
        private int _currentWaveIndex;
        int _lastWaveIndex;
        private float _timeAfterLastSpawn;
        private int _enemyCounter;

        private void Awake()
        {
            SetWave(_currentWaveIndex);
            _lastWaveIndex = _waves.Count - 1;
        }

        private void Update()
        {
            if (_currentWave == null)
                return;

            _timeAfterLastSpawn += Time.deltaTime;

            if (_timeAfterLastSpawn >= _currentWave.Delay)
            {
                CreateEnemy();
                _enemyCounter++;
                _timeAfterLastSpawn = 0;
            }

            if (_enemyCounter >= _waves[_currentWaveIndex].Count)
            {
                _currentWave = null;

                if (_currentWaveIndex < _lastWaveIndex)
                    _allEnemySpawned?.Invoke();
            }
        }

        public void NextWave()
        {
            if (_currentWaveIndex < _lastWaveIndex)
                _currentWaveIndex++;
            else
                _currentWaveIndex -= _lastWaveIndex;

            _enemyCounter -= _enemyCounter;

            SetWave(_currentWaveIndex);
        }

        private void SetWave(int index)
        {
            _currentWave = _waves[index];
        }

        private void CreateEnemy()
        {
            Enemy enemy = Instantiate(
                _currentWave.Prefab,
                transform.position,
                Quaternion.identity,
                transform);

            enemy.Init(_player);
        }
    }

    [System.Serializable]
    public class Wave
    {
        public Enemy Prefab;
        public float Delay;
        public int Count;
    }
}