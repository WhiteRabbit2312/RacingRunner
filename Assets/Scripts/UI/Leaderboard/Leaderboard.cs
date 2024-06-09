using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using Firebase.Database;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    [SerializeField] private Item _prefab;
    private GameObject[] _itemOnScene;
    private GameObject _rowPosition;

    public void LeaderboardButton()
    {
        StartCoroutine(GetUserHighscoreCoroutine());
    }

    private IEnumerator GetUserHighscoreCoroutine()
    {
        var task = DatabaseManager.Instance.Reference.Child("User").GetValueAsync();

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
                if (!item.HasChild("score"))
                    continue;

                Row newRow = new Row();
                newRow.Name = item.Child("name").Value.ToString();
                newRow.Score = int.Parse(item.Child("score").Value.ToString());
                rows.Add(newRow);
            }

            ClearLeaderBoard();
            SortRows(rows);

        }

    }

    private void SortRows(List<Row> rowsToSort)
    {
        int placeCount = 1;

        var sortedList = rowsToSort.OrderByDescending(n => n.Score).ToList();

        List<Row> rowsToSortNew = (List<Row>)sortedList;


        for (int i = 0; i < rowsToSort.Count; ++i)
        {
            Item row = Instantiate(_prefab, _rowPosition.transform);

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
            Destroy(item);
        }
    }
}
