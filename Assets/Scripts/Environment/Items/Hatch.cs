using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Hatch : Chunk
    {
        private float _offsetZ = 10f;

        private void DiscardCar(ref NetworkTransform netObjPlayer)
        {
            Debug.LogError("Discard car");
            //take car transform and discard it
            Vector3 vectorPlayer = netObjPlayer.transform.position;
            netObjPlayer.transform.position = new Vector3(vectorPlayer.x, vectorPlayer.y, vectorPlayer.z - _offsetZ);
        }

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                NetworkTransform netObjPlayer = MyPlayerInfo.Object.GetComponent<NetworkTransform>();
                Debug.LogError("netObjPlayer: " + netObjPlayer.ToString());
                DiscardCar(ref netObjPlayer);
                Effect(ref MyPlayerInfo.Speed);
                DestroyItem();
            }


        }


    }
}