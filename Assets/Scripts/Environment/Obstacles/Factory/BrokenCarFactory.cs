using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class BrokenCarFactory : IObstacleFactory
    {
        private Obstacle _prefab;
        private Transform _obstacleTransform;

        public BrokenCarFactory(Obstacle obstacle)
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