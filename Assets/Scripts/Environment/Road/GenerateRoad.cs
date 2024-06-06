using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;


namespace RacingRunner 
{
    public class GenerateRoad : NetworkBehaviour
    {
        [SerializeField] private Chunk _brokenCarPrefab;
        [SerializeField] private Chunk _spilledOilCarPrefab;
        [SerializeField] private Chunk _hatchPrefab;
        [SerializeField] private Chunk _nitroPrefab;

        [Space]

        [SerializeField] private readonly int _roadLength;
        private List<ChunkFactory> _obstaclesList = new List<ChunkFactory>();

        public override void Spawned()
        {
            _obstaclesList.Add(new BrokenCarFactory(_brokenCarPrefab));
            _obstaclesList.Add(new HatchFactory(_hatchPrefab));
            _obstaclesList.Add(new BrokenCarFactory(_spilledOilCarPrefab));
            _obstaclesList.Add(new NitroFactory(_nitroPrefab));

            GenerateMap();
        }

        private void GenerateMap()
        {
            for(int i = 0; i < _roadLength; ++i)
            {
                int chunkId = ChunkId();
                float step = GenerationStep();
                _obstaclesList[chunkId].CreateChunk(step * i);
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
