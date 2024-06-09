using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class ChunkFactory : NetworkBehaviour 
    {
        protected NetworkObject _prefab;
        public NetworkObject CreateChunk(float obstaclePositionZ)
        {
            Debug.LogError("Chunk spawned" + obstaclePositionZ);
            Vector3 _obstaclePosition = new Vector3(0, 0, obstaclePositionZ);
            Debug.LogError("Chunk prefab: " + _prefab);

            if (BasicSpawner.Instance.NetRunner != null)
            {
                NetworkObject prefabToSpawn = BasicSpawner.Instance.NetRunner.Spawn(_prefab, _obstaclePosition);
                return prefabToSpawn;
            }

            else
            {
                Debug.LogError("Runner is null");
                return null;
            }
            
        }
    }
}
