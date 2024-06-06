using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class HatchFactory : ChunkFactory
    {
        public HatchFactory(Chunk obstacle)
        {
            _prefab = obstacle;
        }

    }
}
