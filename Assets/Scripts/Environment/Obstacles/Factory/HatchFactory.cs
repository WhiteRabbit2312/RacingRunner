using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class HatchFactory : IObstacleFactory
    {
        private ObstacleMovement _prefab;

        public HatchFactory(ObstacleMovement obstacle)
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
