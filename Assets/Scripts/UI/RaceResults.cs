using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using TMPro;
using System.Linq;
using Fusion;
using UnityEngine.SceneManagement;

namespace RacingRunner
{
    public class RaceResults : NetworkBehaviour
    {
        [SerializeField] private TextMeshProUGUI _textBestScore;
        [SerializeField] private TextMeshProUGUI _textPlayerScore;
        [SerializeField] private TextMeshProUGUI _textPlayerPlace;

        private void Awake()
        {
            StartCoroutine(Place());
            Debug.LogError("_textPlayerScore " + _textPlayerScore);
            GetPlayerScore();
        }

        private IEnumerator Place()
        {
            var task = DatabaseManager.Instance.Reference
                .Child(DatabaseConstants.UserTag)
                .OrderByChild(DatabaseConstants.TimeTag)
                .StartAt(1)
                .GetValueAsync();
            yield return new WaitUntil(() => task.IsCompleted);
            List<int> scoreList = new List<int>();

            string userId = AuthorizationManager.Instance.Auth.CurrentUser.UserId;

            int place = 0; 
            foreach(var item in task.Result.Children)
            {
                Debug.LogError("item.Key " + item.Key);
                Debug.LogError("item.Value.ToString() " + item.Value.ToString());
                scoreList.Add(int.Parse(item.Child(DatabaseConstants.TimeTag).Value.ToString()));
                place++;
                if(userId == item.Key)
                {
                    _textPlayerPlace.text = "Place: " + place.ToString();
                }
            }

            _textBestScore.text = "Bast score: " + scoreList.First().ToString();

        }


        private void GetPlayerScore()
        {
            /*
            Debug.LogError("BasicSpawner.Instance " + BasicSpawner.Instance);
            Debug.LogError("PlayersOnSceneDict[Object.InputAuthority] " + BasicSpawner.Instance.PlayersOnSceneDict.First());

            Debug.LogError("PlayerInfo " + BasicSpawner
                .Instance
                .PlayersOnSceneDict[Object.InputAuthority]
                .GetComponent<PlayerInfo>());

            Debug.LogError("Time " + BasicSpawner
                .Instance
                .PlayersOnSceneDict.First().Value
                .GetComponent<PlayerInfo>()
                .Time);
            */
            _textPlayerScore.text 
                = "Score: " + BasicSpawner
                .Instance
                .PlayersOnSceneDict.First().Value
                .GetComponent<PlayerInfo>()
                .Time.ToString();

        }

        public void BackToMenu()
        {
            SceneManager.LoadScene(DatabaseConstants.MenuSceneID);
        }
    }
}
