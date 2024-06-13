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
        private int _timer = 300;

        public override void FixedUpdateNetwork()
        {
            CloseCountDownPanel(_timer);

            _countDownText.text = $"{_timer / GameplayConstants.TickPerSecond}";

            _timer = (int)(_timer * Runner.DeltaTime);
        }

        private void CloseCountDownPanel(int timer)
        {
            
            if (timer <= 0)
            {
                foreach(var item in BasicSpawner.Instance.PlayersOnScene)
                {
                    item.GetComponent<PlayerMovement>().StartRace = true;
                }
                Debug.LogError("Close");
                
            }

        }

        public int GetTimerTime()
        {
            return _timer;
        }
    }
}
