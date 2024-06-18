using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using RacingRunner;
using System;

public class ConnectPlayers : NetworkBehaviour
{
    [Networked, Capacity(5)]
    public NetworkDictionary<PlayerRef, NetworkObject> PlayersOnSceneDict => default;

    private void Awake()
    {
        BasicSpawner.Instance.GetComponent<NetworkEvents>().PlayerJoined.AddListener(Jopa);
    }

    private void Jopa(NetworkRunner runner, PlayerRef playerRef)
    {
        Debug.Log("DSFPOmfes;lkf,ms:LEF");
    }
}
