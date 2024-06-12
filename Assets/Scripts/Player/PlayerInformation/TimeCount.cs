using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace RacingRunner 
{
    public class TimeCount : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _timeText;
        private int _timer = 0;
        private const int SecondsToDiv = 60;

        private void Update()
        {
            _timeText.text = CreateTimer();
            _timer++;
        }

        private string CreateTimer()
        {
            string timer = (_timer / SecondsToDiv).ToString() + " : " + (_timer % SecondsToDiv);
            return timer;
        }
    }
}
