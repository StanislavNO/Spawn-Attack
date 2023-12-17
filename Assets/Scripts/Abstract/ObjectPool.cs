using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace Assets.Scripts
{
    public class ObjectPool : MonoBehaviour
    {
        [SerializeField] private GameObject _container;

        private List<GameObject> _pool = new();

        protected void Initialize(GameObject _prefab)
        {
            _prefab.SetActive(false);
            _pool.Add(_prefab);
        }

        protected bool TryGetObject(out GameObject result)
        {
            result = _pool.FirstOrDefault(p => p.activeSelf == false);

            return result != null;
        }
    }
}