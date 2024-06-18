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
        [SerializeField] private GetUserAccountData _getUserAccountData;
        private int _timer = 300;
        private int _step = 2;

        public override void FixedUpdateNetwork()
        {
            if (_getUserAccountData.StartCountDown)
            {
                GetTimeToStart(_timer);

                _countDownText.text = $"{_timer / GameplayConstants.TickPerSecond}";
                _timer -= _step;
            }
        }

        private void GetTimeToStart(int timer)
        {
            if (timer <= 0)
            {
                /*
                foreach(var item in BasicSpawner.Instance.PlayersOnSceneDict)
                {
                    item.Value.GetComponent<PlayerMovement>().StartRace = true;
                    _countDownPanel.SetActive(false);
                }
                */
            }

        }

        public int GetTimerTime()
        {
            return _timer;
        }
    }
}
