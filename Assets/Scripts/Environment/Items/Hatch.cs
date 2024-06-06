using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Hatch : Chunk
    {
        private void DiscardCar(NetworkTransform carTransform)
        {
            //take car transform and discard it
        }

        public override void FixedUpdateNetwork()
        {
            DetectHit();
        }

    }
}