using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Fusion;

namespace RacingRunner 
{
    public class WaitingScreen : NetworkBehaviour
    {
        [SerializeField] private TimerBeforeRace _timerBeforeRace;
        [SerializeField] private GameObject _startButton;
        [SerializeField] private GameObject _waitingText;

        private void Update()
        {
            //Debug.LogError("Player amount: " + BasicSpawner.Instance.PlayersOnSceneDict.Count);
            /*
            if(BasicSpawner.Instance.PlayersOnSceneDict.Count == GameplayConstants.RequiredPlayerAmount)
            {
                _startButton.SetActive(true);
                _waitingText.SetActive(false);
            }*/
            
        }
    }
}
