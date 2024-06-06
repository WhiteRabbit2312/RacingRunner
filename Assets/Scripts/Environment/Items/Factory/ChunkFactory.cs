using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class ChunkFactory 
    {
        private Transform _obstacleTransform;
        protected Chunk _prefab;
        public Chunk CreateChunk(float obstaclePositionZ)
        {
            _obstacleTransform.position = new Vector3(0, 0, obstaclePositionZ);
            Chunk prefabToSpawn = GameObject.Instantiate(_prefab, _obstacleTransform);
            return prefabToSpawn;
        }
    }
}
