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
        
        private int _timer = 0;
        private const int SecondsToDiv = 60;

        private void Update()
        {
            _timeText.text = CreateTimer();
            _speedText.text = Speed.ToString();
            _timer++;
            Time = _timer;
        }

        private string CreateTimer()
        {
            string timer = (_timer / SecondsToDiv).ToString() + " : " + (_timer % SecondsToDiv);
            return timer;
        }

        public override void FixedUpdateNetwork()
        {

            Debug.LogError("Speed: " + Speed);
        }
    }
}
