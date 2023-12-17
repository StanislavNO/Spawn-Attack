using UnityEngine;

namespace Assets.Scripts.Abstract
{
    public class Destroyer : MonoBehaviour
    {
        public void OnTriggerEnter2D(Collider2D collision)
        {
            collision.gameObject.SetActive(false);
        }
    }
}