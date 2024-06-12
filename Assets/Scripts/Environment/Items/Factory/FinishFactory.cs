using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class FinishFactory : ChunkFactory
    {
        public FinishFactory(NetworkObject obstacle)
        {
            _prefab = obstacle;
        }
    }
}
