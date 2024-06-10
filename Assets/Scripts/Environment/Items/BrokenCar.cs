using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class BrokenCar : Chunk
    {
        public override void DetectHit()
        {
            base.DetectHit();
            if(MyPlayerInfo != null)
            {
                Effect(ref MyPlayerInfo.Speed);
                DestroyItem();
            }
            
            
        }

    }
}
