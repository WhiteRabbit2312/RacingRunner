using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class BrokenCarFactory : IObstacleFactory
    {
        private ObstacleMovement _prefab;

        public BrokenCarFactory(ObstacleMovement obstacle)
        {
            _prefab = obstacle;
        }

        public ObstacleMovement CreateObstacle()
        {
            ObstacleMovement prefabToSpawn = GameObject.Instantiate(_prefab);
            return prefabToSpawn;
        }
    }
}