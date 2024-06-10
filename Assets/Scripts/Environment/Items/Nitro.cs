using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Nitro : Chunk
    {
        [SerializeField] private float _nitroAmount;


        /*
        public override void Effect(ref float stat)
        {
            stat += _nitroAmount;
        }*/

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {

                //Effect(ref MyPlayerInfo.Speed);
                DestroyItem();
            }


        }

    }
}
