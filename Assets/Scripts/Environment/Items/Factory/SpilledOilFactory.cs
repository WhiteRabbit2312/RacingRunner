using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class SpilledOilFactory : ChunkFactory
    {
        public SpilledOilFactory(Chunk obstacle)
        {
            _prefab = obstacle;
        }
    }
}
