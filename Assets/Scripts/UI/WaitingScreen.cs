using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;

namespace RacingRunner 
{
    public class WaitingScreen : NetworkBehaviour
    {
        [SerializeField] private GameObject _waitingPanel;
        [SerializeField] private GameObject _showPlayersPanel;
        [SerializeField] private TimerBeforeRace _timerBeforeRace;


        private void Update()
        {
            if(BasicSpawner.Instance.PlayersOnScene.Count == GameplayConstants.RequiredPlayerAmount)
            {
                _waitingPanel.SetActive(false);

                Debug.LogError("Timer time " + _timerBeforeRace.GetTimerTime());

                if(_timerBeforeRace.GetTimerTime() <= 0)
                {
                    _showPlayersPanel.SetActive(false);
                }

                else
                {
                    _showPlayersPanel.SetActive(true);
                }
            }
            
        }
    }
}
