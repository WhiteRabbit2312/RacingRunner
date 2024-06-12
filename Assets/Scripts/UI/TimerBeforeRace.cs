using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

namespace RacingRunner 
{
    public class TimerBeforeRace : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI _countDownText;
        private int _timer;
        private int _seconds = 5;

        public override void Spawned()
        {
            _timer = _seconds * GameplayConstants.TickPerSecond;
        }

        public override void FixedUpdateNetwork()
        {
            CloseCountDownPanel(_timer);

            _countDownText.text = $"{_timer / GameplayConstants.TickPerSecond} : {_timer % GameplayConstants.TickPerSecond}"; 
            _timer--;
        }

        private void CloseCountDownPanel(int timer)
        {
            if(timer == 0)
            {
                Object.gameObject.SetActive(false);
            }
        }
    }
}
