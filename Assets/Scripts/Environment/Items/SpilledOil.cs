using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class SpilledOil : Chunk
    {
        private float _tempSpeed;

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                _tempSpeed = MyPlayerInfo.Speed;
                Effect(ref MyPlayerInfo.Speed);
                MyPlayerInfo.Speed = _tempSpeed;
                DestroyItem();
            }

        }


        public override void Effect(ref float stat)
        {
            base.Effect(ref stat);
            StartCoroutine(Timer());
        }

        private IEnumerator Timer()
        {
            yield return new WaitForSeconds(5f);
        }
    }
}
