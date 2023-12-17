using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : ObjectPool
    {
        [SerializeField] private UnityEvent _enemySpawned;
        [SerializeField] private UnityEvent _allEnemySpawned;
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Player _player;

        private Wave _currentWave;
        private int _currentWaveIndex;
        private int _lastWaveIndex;
        private float _timeAfterLastSpawn;
        private int _enemyCounter;

        public int MaxEnemy { get; private set; }
        public int EnemyCounter => _enemyCounter;

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
                _enemyCounter++;
                _timeAfterLastSpawn = 0;

                if (TryGetObject(out GameObject enemy))
                {
                    SetEnemy(enemy, transform.position);
                }
                else
                    CreateEnemy();
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
            MaxEnemy = _currentWave.Count;
        }

        private void SetEnemy(GameObject enemy, Vector3 spawnPoint)
        {
            enemy.SetActive(true);
            enemy.transform.position = spawnPoint;

            _enemySpawned?.Invoke();
        }

        private void CreateEnemy()
        {
            Enemy enemy = Instantiate(
                _currentWave.Prefab,
                transform.position,
                Quaternion.identity,
                transform);

            enemy.Init(_player);

            Initialize(enemy.gameObject);
            SetEnemy(enemy.gameObject, transform.position);

            _enemySpawned?.Invoke();
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