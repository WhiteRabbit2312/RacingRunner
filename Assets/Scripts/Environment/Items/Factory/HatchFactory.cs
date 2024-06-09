using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class HatchFactory : ChunkFactory
    {
        public HatchFactory(NetworkObject obstacle)
        {
            _prefab = obstacle;
        }

    }
}
