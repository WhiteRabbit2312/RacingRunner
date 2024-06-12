using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RacingRunner 
{
    public class WaitingScreen : MonoBehaviour
    {
        [SerializeField] private GameObject _waitingPanel;
        [SerializeField] private GameObject _countDownPanel;
        

        private void Update()
        {
            if(BasicSpawner.Instance.PlayersOnScene.Count == GameplayConstants.RequiredPlayerAmount)
            {
                _waitingPanel.SetActive(false);
                _countDownPanel.SetActive(true);
            }
            
        }
    }
}
