using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RacingRunner
{
    public class BasicSpawner : SimulationBehaviour
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private Button _connectButton;

        public static BasicSpawner Instance;

        [HideInInspector] public NetworkRunner NetRunner;
        
        private string _sessionName = "TestRoom";

        private void Awake()
        {
            Instance = this;
            _connectButton.onClick.AddListener(ConnectButton);
        }

        public async void StartGame(GameMode mode)
        {
            if (NetRunner != null)
                return;

            NetRunner = gameObject.AddComponent<NetworkRunner>();
            Debug.LogError("1");
            var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
            var sceneInfo = new NetworkSceneInfo();
            if (scene.IsValid)
            {
                sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
            }
            Debug.LogError("2");
            await NetRunner.StartGame(new StartGameArgs()
            {
                
                GameMode = mode,
                SessionName = _sessionName,
                Scene = SceneRef.FromIndex(DatabaseConstants.WaitingSceneID),
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
            Debug.LogError("3");
        }

        public void ConnectButton()
        {
            StartGame(GameMode.Shared);
        }

        /*
        public void PlayerJoined(PlayerRef player)
        {
            Debug.LogError("Player joined");

            Runner.Spawn(_playerPrefab, _spawnPoint, Quaternion.identity);

            //Debug.LogError("PlayersOnSceneDict " + PlayersOnSceneDict.Count);

            //PlayersOnSceneDict.Add(player, spawnedPlayer);


        }*/
    }
}
