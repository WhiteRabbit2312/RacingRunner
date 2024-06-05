using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class ObstacleMovement : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _dirVector;

        public override void FixedUpdateNetwork()
        {
            MoveObstacle();
        }

        private void MoveObstacle()
        {
            transform.Translate(_dirVector.normalized * _speed * Time.deltaTime);
        }
    }
}
