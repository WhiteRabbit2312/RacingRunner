using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class OpponentLook : NetworkBehaviour
{
    public override void Spawned()
    {
        if (!HasStateAuthority)
        {
            BoxCollider playerCollider = GetComponent<BoxCollider>();
            playerCollider.enabled = false;
        }
    }
}
