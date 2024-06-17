using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace RacingRunner
{
    public class BasicSpawner : SimulationBehaviour, IPlayerJoined
    {
        [SerializeField] private NetworkObject _playerPrefab;
        [SerializeField] private Vector3 _spawnPoint;
        [SerializeField] private Button _connectButton;

        public static BasicSpawner Instance;
        public Dictionary<PlayerRef, NetworkObject> PlayersOnSceneDict = new Dictionary<PlayerRef, NetworkObject>();

        [HideInInspector] public NetworkRunner NetRunner;
        
        private string _sessionName = "TestRoom";


        private void Awake()
        {
            DontDestroyOnLoad(this);
            Instance = this;
            _connectButton.onClick.AddListener(ConnectButton);
        }

        public async void StartGame(GameMode mode)
        {
            if (NetRunner != null)
                return;

            NetRunner = gameObject.AddComponent<NetworkRunner>();

            var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
            var sceneInfo = new NetworkSceneInfo();
            if (scene.IsValid)
            {
                sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
            }

            await NetRunner.StartGame(new StartGameArgs()
            {
                GameMode = mode,
                SessionName = _sessionName,
                Scene = SceneRef.FromIndex(DatabaseConstants.GameScene),
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }

        public void ConnectButton()
        {
            StartGame(GameMode.Shared);
        }

        public void PlayerJoined(PlayerRef player)
        {
            Debug.LogError("Player joined");
            if (player == Runner.LocalPlayer)
            {
                NetworkObject spawnedPlayer = Runner.Spawn(_playerPrefab, _spawnPoint, Quaternion.identity);

                PlayersOnSceneDict.Add(player, spawnedPlayer);
            }
        }
    }
}
