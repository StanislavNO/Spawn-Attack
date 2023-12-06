using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Player player;

        private Wave _currentWave;
        private int _currentWaveIndex;
        private float _timeAfterLastSpawn;
    }

    [System.Serializable]
    public class Wave
    {
        public GameObject Template;
        public int Delay;
        public int Count;
    }
}