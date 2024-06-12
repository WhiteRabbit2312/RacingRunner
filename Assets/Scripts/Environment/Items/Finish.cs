using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner
{
    public class Finish : Chunk
    {
        private SetUserData _setUserData;

        public override void Spawned()
        {
            _setUserData = gameObject.AddComponent<SetUserData>();
        }

        public override void DetectHit()
        {
            base.DetectHit();
            _setUserData.WriteScore(AuthorizationManager.Instance.UserID, MyPlayerInfo.Time);
        }


    }
}
