using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

namespace RacingRunner
{
    public class Nitro : Chunk
    {
        
        public override void Effect(ref float stat)
        {
            stat += ChangeStat;
        }

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                Effect(ref MyPlayerInfo.Nitro);
                DestroyItem();
            }


        }

    }
}
