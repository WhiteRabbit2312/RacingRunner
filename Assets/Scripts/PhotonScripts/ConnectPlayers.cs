using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using RacingRunner;

public class ConnectPlayers : NetworkBehaviour
{
    [SerializeField] private GameObject _waitingPanel;
    private GetUserAccountData _getUserAccountData;
    [Networked]
    public NetworkDictionary<PlayerRef, NetworkObject> PlayersOnSceneDict => default;

    public override void Spawned()
    {
        _getUserAccountData = GetComponent<GetUserAccountData>();

        AddPlayer(Runner.LocalPlayer);
    }

    private void AddPlayer(PlayerRef player)
    {
        //Debug.LogError("Object.InputAuthority: " + Object.InputAuthority);
        //Debug.LogError("Runner.LocalPlayer: " + Runner.LocalPlayer);
        Debug.LogError("Local player");
        PlayersOnSceneDict.Add(player, Object);

        Debug.LogError("PlayersOnSceneDict " + PlayersOnSceneDict.Count);

        if (PlayersOnSceneDict.Count == GameplayConstants.RequiredPlayerAmount)
        {
            CloseWaitingPanel();
        }
    }

    [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsHostPlayer)]
    public void RPC_SendMessage()
    {
        RPC_RelayMessage();
    }

    [Rpc(RpcSources.All, RpcTargets.All, HostMode = RpcHostMode.SourceIsServer)]
    public void RPC_RelayMessage()
    {
        _getUserAccountData.StartGame();
        _waitingPanel.SetActive(false);
    }

    private void CloseWaitingPanel()
    {
        RPC_SendMessage();

    }

}
