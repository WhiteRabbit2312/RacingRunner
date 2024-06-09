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

        private int _scene = 2;
        public List<NetworkObject> PlayersOnScene = new List<NetworkObject>();
        [HideInInspector] public NetworkRunner NetRunner;

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

            var scene = SceneRef.FromIndex(SceneManager.GetActiveScene().buildIndex);
            var sceneInfo = new NetworkSceneInfo();
            if (scene.IsValid)
            {
                sceneInfo.AddSceneRef(scene, LoadSceneMode.Additive);
            }

            await NetRunner.StartGame(new StartGameArgs()
            {
                GameMode = mode,
                SessionName = "TestRoom",
                Scene = SceneRef.FromIndex(_scene),
                SceneManager = gameObject.AddComponent<NetworkSceneManagerDefault>()
            });
        }

        public void ConnectButton()
        {
            StartGame(GameMode.Shared);
        }

        public void PlayerJoined(PlayerRef player)
        {
            if (player == Runner.LocalPlayer)
            {
                Runner.Spawn(_playerPrefab, _spawnPoint, Quaternion.identity);
            }
        }
    }
}
