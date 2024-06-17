using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class SpawnCarModel : NetworkBehaviour
    {
        [SerializeField] private GameObject[] _carModelPrefabs;
        [SerializeField] private Transform _spawnPlace;

        public override void Spawned()
        {
            int carIdx = PlayerPrefs.GetInt(GameplayConstants.CarTag);
            Runner.Spawn(_carModelPrefabs[carIdx], _spawnPlace.transform.position);
        }
    }
}
