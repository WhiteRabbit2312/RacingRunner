using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class Hatch : Chunk
    {
        private float offsetZ = 5f;
        private void DiscardCar(ref NetworkTransform netObjPlayer)
        {
            //take car transform and discard it
            Vector3 vectorPlayer = netObjPlayer.transform.position;
            netObjPlayer.transform.position = new Vector3(vectorPlayer.x, vectorPlayer.y, vectorPlayer.z - offsetZ);
        }

        public override void DetectHit()
        {
            base.DetectHit();
            if (MyPlayerInfo != null)
            {
                NetworkTransform netObjPlayer = MyPlayerInfo.Object.GetComponent<NetworkTransform>();
                DiscardCar(ref netObjPlayer);
                Effect(ref MyPlayerInfo.Speed);
                DestroyItem();
            }


        }


    }
}