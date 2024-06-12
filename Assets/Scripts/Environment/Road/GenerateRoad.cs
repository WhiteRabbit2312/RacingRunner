using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using System.Linq;

namespace RacingRunner 
{
    public class GenerateRoad : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _brokenCarPrefab;
        [SerializeField] private NetworkObject _spilledOilCarPrefab;
        [SerializeField] private NetworkObject _hatchPrefab;
        [SerializeField] private NetworkObject _nitroPrefab;
        [SerializeField] private NetworkObject _emptyPrefab;
        [SerializeField] private NetworkObject _finishPrefab;

        [Space]

        [SerializeField] private int _emptyChunkCount;

        [SerializeField] private int _testChunk;

        [Networked] int _chunkId { get; set; }

        [Space]

        [SerializeField] private int _roadLength;
        private List<ChunkFactory> _obstaclesList = new List<ChunkFactory>();
        

        public override void Spawned()
        {
            _obstaclesList.Add(new EmptyChunkFactory(_emptyPrefab));
            _obstaclesList.Add(new BrokenCarFactory(_brokenCarPrefab));
            _obstaclesList.Add(new HatchFactory(_hatchPrefab));
            _obstaclesList.Add(new SpilledOilFactory(_spilledOilCarPrefab));
            _obstaclesList.Add(new NitroFactory(_nitroPrefab));
            _obstaclesList.Add(new FinishFactory(_nitroPrefab));
            
            GenerateMap();
        }

        private void GenerateMap()
        {
            SpawnEmptyChunks();
            SpawnRandomChunks();
            SpawnFinishChunk();
        }

        private void SpawnEmptyChunks()
        {
            for (int i = 0; i < _emptyChunkCount; ++i)
            {
                float step = GenerationStep();
                _obstaclesList[_chunkId].CreateChunk(step * i);
            }
        }
        private void SpawnRandomChunks()
        {
            for (int i = _emptyChunkCount; i < _roadLength; ++i)
            {
                _chunkId = ChunkId();
                float step = GenerationStep();
                _obstaclesList[_chunkId].CreateChunk(i * step);
            }
        }

        private void SpawnFinishChunk()
        {
            float stepForLastChunk = GenerationStep();
            _obstaclesList.Last().CreateChunk(_roadLength * stepForLastChunk);
        }

        private int ChunkId()
        {
            int chunk = Random.Range(0, _obstaclesList.Count);
            return chunk;
        }

        private float GenerationStep()
        {
            float step = _emptyPrefab.transform.localScale.z;
            return step;
        }
    }
}
