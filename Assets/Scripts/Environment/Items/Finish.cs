using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Finish : Chunk
    {
        [SerializeField] private NetworkObject _finalPanelPrefab;
        private SetUserData _setUserData;

        public override void Spawned()
        {
            _setUserData = gameObject.AddComponent<SetUserData>();
        }

        public override void DetectHit()
        {
            base.DetectHit();
            _setUserData.WriteScore(AuthorizationManager.Instance.Auth.CurrentUser.UserId, MyPlayerInfo.Time);
            Runner.Spawn(_finalPanelPrefab);

            Debug.LogError("Finish");
        }


    }
}
