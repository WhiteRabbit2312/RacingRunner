using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class BrokenCarFactory : ChunkFactory
    {
        public BrokenCarFactory(NetworkObject obstacle)
        {
            _prefab = obstacle;
        }

    }
}