using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class GenerateRoad : NetworkBehaviour
    {
        [SerializeField] private Obstacle _brokenCarPrefab;
        [SerializeField] private Obstacle _spilledOilCarPrefab;
        [SerializeField] private Obstacle _hatchPrefab;

        [Space]

        [SerializeField] private readonly int _roadLength;
        private List<IObstacleFactory> _obstaclesList = new List<IObstacleFactory>();

        public override void Spawned()
        {
            _obstaclesList.Add(new BrokenCarFactory(_brokenCarPrefab));
            _obstaclesList.Add(new HatchFactory(_hatchPrefab));
            _obstaclesList.Add(new BrokenCarFactory(_spilledOilCarPrefab));

            GenerateMap();
        }

        private void GenerateMap()
        {
            for(int i = 0; i < _roadLength; ++i)
            {
                int chunkId = ChunkId();
                float step = GenerationStep();
                _obstaclesList[chunkId].CreateObstacle(step * i);
            }
        }

        private int ChunkId()
        {
            int chunk = Random.Range(0, _obstaclesList.Count);
            return chunk;
        }

        private float GenerationStep()
        {
            float step = _brokenCarPrefab.GetComponent<Renderer>().bounds.max.y;
            return step;
        }
    }
}
