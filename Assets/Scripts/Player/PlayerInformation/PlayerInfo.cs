using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
using TMPro;

namespace RacingRunner
{
    public class PlayerInfo : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        [SerializeField] private TextMeshProUGUI _speedText;
        [SerializeField] private TextMeshProUGUI _nitroText;

        public float Speed;
        public float Nitro;
        public int Time;

        private PlayerMovement _playerMovement;
        private int _timer = 0;

        public override void Spawned()
        {
            _playerMovement = GetComponent<PlayerMovement>();



            //BasicSpawner.Instance.PlayersOnSceneDict.Add(Object.InputAuthority, Object);


            //Debug.LogError("Basic spawner: " + BasicSpawner.Instance.PlayersOnSceneDict.Keys);
        }

        private void Update()
        {
            if (!_playerMovement.StartRace)
                return;

            _timeText.text = CreateTimer();
            _speedText.text = Speed.ToString();
            _nitroText.text = Nitro.ToString();
            _timer++;
            Time = _timer;

            //Debug.LogError("Speed: " + Speed);
        }

        private string CreateTimer()
        {
            string timer = (_timer / GameplayConstants.TickPerSecond).ToString() + " : " + (_timer % GameplayConstants.TickPerSecond);
            return timer;
        }
    }
}
