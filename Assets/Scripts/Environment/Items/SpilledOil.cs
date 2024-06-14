using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class SpilledOil : Chunk
    {
        private float _tempSpeed;
        private int _effectDurration = 300;
        private bool _detectHit = false;

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                if (!_detectHit)
                {
                    _tempSpeed = MyPlayerInfo.Speed;
                    _detectHit = true;
                }
                
                Timer();

            }

        }

        private void Timer()
        {
            if(_effectDurration > 0)
            {
                Effect(ref MyPlayerInfo.Speed);
                _effectDurration--;
                //Debug.LogError("_effectDurration " + _effectDurration);
            }

            else
            {
                DestroyItem();
                MyPlayerInfo.Speed = _tempSpeed;
            }
            

        }

        public override void Effect(ref float stat)
        {
            stat = ChangeStat;

        }

    }
}
