using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner
{
    public class PlayerInfo : NetworkBehaviour
    {
        public float Speed;
        [HideInInspector] public float Nitro;

        public override void FixedUpdateNetwork()
        {
            Debug.LogError("Speed: " + Speed);
        }
    }
}
