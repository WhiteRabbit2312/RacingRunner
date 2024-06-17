using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

namespace RacingRunner
{
    public class GameScore : MonoBehaviour
    {
        protected List<Row> Rows = new List<Row>();

        public virtual IEnumerator GetUserScoreCoroutine()
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

                foreach (var item in snapshot.Children)
                {
                    if (!item.HasChild(DatabaseConstants.TimeTag))
                        continue;

                    Row newRow = new Row();
                    newRow.Name = item.Child(DatabaseConstants.NameTag).Value.ToString();
                    newRow.Score = int.Parse(item.Child(DatabaseConstants.TimeTag).Value.ToString());
                    Rows.Add(newRow);

                }


            }
        }
    }
}