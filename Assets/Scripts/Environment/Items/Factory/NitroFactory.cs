using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class NitroFactory : ChunkFactory
    {

        public NitroFactory(Chunk obstacle)
        {
            _prefab = obstacle;
        }

    }
}
