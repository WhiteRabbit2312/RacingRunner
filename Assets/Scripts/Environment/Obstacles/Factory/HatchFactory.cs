using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class HatchFactory : IObstacleFactory
    {
        private Obstacle _prefab;
        private Transform _obstacleTransform;

        public HatchFactory(Obstacle obstacle)
        {
            _prefab = obstacle;
        }

        public Obstacle CreateObstacle(float obstaclePositionZ)
        {
            _obstacleTransform.position = new Vector3(0, 0, obstaclePositionZ);
            Obstacle prefabToSpawn = GameObject.Instantiate(_prefab, _obstacleTransform);
            return prefabToSpawn;
        }
    }
}
