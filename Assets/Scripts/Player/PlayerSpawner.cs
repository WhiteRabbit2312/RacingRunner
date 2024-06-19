using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class PlayerSpawner : NetworkBehaviour
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        public override void Spawned()
        {
            Debug.LogError("Spawned");
            BasicSpawner.Instance.NetRunner.Spawn(_playerPrefab, _spawnPoint, Quaternion.identity);
        }
    }
}
