using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using RacingRunner;

public class ConnectPlayers : NetworkBehaviour, IPlayerJoined
{
    [SerializeField] private GameObject _waitingPanel;
    private GetUserAccountData _getUserAccountData;
    [Networked, OnChangedRender("AddPlayer")]
    public NetworkDictionary<PlayerRef, NetworkObject> PlayersOnSceneDict => default;

    private void Awake()
    {
        _getUserAccountData = GetComponent<GetUserAccountData>();
    }

    private void AddPlayer(PlayerRef player)
    {
        Debug.LogError("Object.InputAuthority: " + Object.InputAuthority);
        Debug.LogError("Runner.LocalPlayer: " + Runner.LocalPlayer);
        if (player == Runner.LocalPlayer)
        {
            Debug.LogError("Local player");
            PlayersOnSceneDict.Add(player, Object);
        }

        Debug.LogError("PlayersOnSceneDict " + PlayersOnSceneDict.Count);

        if (PlayersOnSceneDict.Count == GameplayConstants.RequiredPlayerAmount)
        {
            _getUserAccountData.StartGame();
            _waitingPanel.SetActive(false);
        }
    }

    public void PlayerJoined(PlayerRef player)
    {
        AddPlayer(player);
    }
}
