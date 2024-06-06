using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class SpilledOilFactory : IObstacleFactory
    {
        private Obstacle _prefab;

        public SpilledOilFactory(Obstacle obstacle)
        {
            _prefab = obstacle;
        }

        public Obstacle CreateObstacle()
        {
            Obstacle prefabToSpawn = GameObject.Instantiate(_prefab);
            return prefabToSpawn;
        }
    }
}
