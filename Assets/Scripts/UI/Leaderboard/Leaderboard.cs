using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using System.Linq;
using UnityEngine.UI;

namespace RacingRunner
{
    public class Leaderboard : MonoBehaviour
    {
        [SerializeField] private Item _prefab;
        [SerializeField] private GameObject _rowPosition;

        private List<Item> _itemOnScene = new List<Item>();

        public void LeaderboardButton()
        {
            StartCoroutine(GetUserHighscoreCoroutine());
        }

        private IEnumerator GetUserHighscoreCoroutine()
        {
            var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).GetValueAsync();

            yield return new WaitUntil(() => task.IsCompleted);

            if (task.IsFaulted || task.IsCanceled)
            {
                Debug.LogError("Error when getting highscore");
            }
            else
            {
                DataSnapshot snapshot = task.Result;
                List<Row> rows = new List<Row>();

                foreach (var item in snapshot.Children)
                {
                    if (!item.HasChild(DatabaseConstants.TimeTag))
                        continue;

                    Row newRow = new Row();


                    newRow.Name = item.Child(DatabaseConstants.NameTag).Value.ToString();
                    newRow.Score = int.Parse(item.Child(DatabaseConstants.TimeTag).Value.ToString());
                    if(newRow.Score != 0)
                    {
                        rows.Add(newRow);

                    }

                }

                ClearLeaderBoard();
                SortRows(rows);

            }

        }

        private void SortRows(List<Row> rowsToSort)
        {
            int placeCount = 1;

            var sortedList = rowsToSort.OrderByDescending(n => n.Score).ToList();

            sortedList.Reverse();

            List<Row> rowsToSortNew = (List<Row>)sortedList;


            for (int i = 0; i < rowsToSort.Count; ++i)
            {
                Item row = Instantiate(_prefab, _rowPosition.transform);
                _itemOnScene.Add(row);
                row.PlaceText.text = placeCount.ToString();
                row.NameText.text = rowsToSortNew[i].Name;

                row.ScoreText.text = rowsToSortNew[i].Score.ToString();
                placeCount++;
            }
        }

        private void ClearLeaderBoard()
        {
            foreach (var item in _itemOnScene)
            {
                Destroy(item.gameObject);
            }
        }
    }
}