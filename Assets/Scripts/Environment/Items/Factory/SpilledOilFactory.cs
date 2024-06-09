using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class SpilledOilFactory : ChunkFactory
    {
        public SpilledOilFactory(NetworkObject obstacle)
        {
            _prefab = obstacle;
        }
    }
}
