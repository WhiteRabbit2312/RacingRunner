using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class SpilledOilFactory : IObstacleFactory
    {
        private ObstacleMovement _prefab;

        public SpilledOilFactory(ObstacleMovement obstacle)
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
