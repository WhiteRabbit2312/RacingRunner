using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class GenerateRoad : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _brokenCarPrefab;
        [SerializeField] private NetworkObject _spilledOilCarPrefab;
        [SerializeField] private NetworkObject _hatchPrefab;
        [SerializeField] private NetworkObject _nitroPrefab;
        [SerializeField] private NetworkObject _emptyPrefab;

        [SerializeField] private int _testChunk;

        [Networked] int _chunkId { get; set; }

        [Space]

        [SerializeField] private int _roadLength;
        private List<ChunkFactory> _obstaclesList = new List<ChunkFactory>();

        public override void Spawned()
        {
            _obstaclesList.Add(new BrokenCarFactory(_brokenCarPrefab));
            _obstaclesList.Add(new HatchFactory(_hatchPrefab));
            _obstaclesList.Add(new SpilledOilFactory(_spilledOilCarPrefab));
            _obstaclesList.Add(new NitroFactory(_nitroPrefab));
            _obstaclesList.Add(new EmptyChunkFactory(_emptyPrefab));
            //Debug.LogError("Road spawned");
            GenerateMap();
        }

        private void GenerateMap()
        {
            for(int i = 0; i < _roadLength; ++i)
            {
                //Debug.LogError("Spawned chunk: " + i);
                _chunkId = _testChunk; //ChunkId();
                float step = GenerationStep();
                _obstaclesList[_chunkId].CreateChunk(step * i);
            }
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
