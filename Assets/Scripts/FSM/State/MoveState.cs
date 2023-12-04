using System.Collections;
using UnityEngine;

namespace Assets.Scripts
{
    public class MoveState : State
    {
        [SerializeField] private float _speed;

        void Update()
        {
            transform.position = Vector2.MoveTowards(
                transform.position, 
                Target.transform.position,
                _speed * Time.deltaTime);
        }
    }
}