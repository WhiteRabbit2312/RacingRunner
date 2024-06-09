using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class NitroFactory : ChunkFactory
    {
        public NitroFactory(NetworkObject obstacle)
        {
            _prefab = obstacle;
        }

    }
}
