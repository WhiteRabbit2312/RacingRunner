using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

namespace RacingRunner 
{
    public class TimerBeforeRace : NetworkBehaviour
    {
        [SerializeField] private GameObject _countDownPanel;
        [SerializeField] private TextMeshProUGUI _countDownText;
        private int _timer = 300;
        private int _step = 2;
        private bool _startMove = false;

        public bool StartMove
        {
            set
            {
                _startMove = value;
            }

            get
            {
                return _startMove;
            }
        }

        public override void FixedUpdateNetwork()
        {

            GetTimeToStart(_timer);

            _countDownText.text = $"{_timer / GameplayConstants.TickPerSecond}";
            _timer -= _step;

        }

        private void GetTimeToStart(int timer)
        {
            if (timer <= 0)
            {
                //foreach(var item in _connectPlayers.PlayersOnSceneDict)
                //{
                //item.Value.GetComponent<PlayerMovement>().StartRace = true;
                _startMove = true;
                _countDownPanel.SetActive(false);
                //}

            }

        }

        public int GetTimerTime()
        {
            return _timer;
        }
    }
}
