using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

public class OpponentLook : NetworkBehaviour
{
    public override void Spawned()
    {
        if (!HasInputAuthority)
        {
            BoxCollider playerCollider = GetComponent<BoxCollider>();
            playerCollider.gameObject.SetActive(false);
        }
    }
}
