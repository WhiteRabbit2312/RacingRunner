using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;

public class UserInDatabase : MonoBehaviour
{
    public void WriteNewUser(string userId)
    {
        DatabaseManager.Instance.Reference.Child("User").Child(userId);
    }

    public void WriteScore(string userId, int score)
    {
        DatabaseManager.Instance.Reference.Child("User").Child(userId).Child("score").SetValueAsync(score);
    }

    public void WriteName(string userId, string name)
    {
        DatabaseManager.Instance.Reference.Child("User").Child(userId).Child("name").SetValueAsync(name);

    }
}
