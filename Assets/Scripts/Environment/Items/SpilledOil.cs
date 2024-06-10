using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class SpilledOil : Chunk
    {
        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                Effect(ref MyPlayerInfo.Speed);
                DestroyItem();
            }


        }

        public override void Effect(ref float speed)
        {
            
        }

        private void Timer()
        {

        }
    }
}
