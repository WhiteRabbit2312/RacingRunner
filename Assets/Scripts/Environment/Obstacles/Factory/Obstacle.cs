using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Obstacle : NetworkBehaviour
    {
        [SerializeField] private float _speed;
        private Vector3 _dirVector;

        public override void FixedUpdateNetwork()
        {
            
        }


    }
}
