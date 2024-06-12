using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;
using Firebase;

public class SetUserData : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void WriteNewUser(string userId)
    {
        DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userId);
    }

    public void WriteScore(string userId, int time)
    {
        DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userId).Child(DatabaseConstants.TimeTag).SetValueAsync(time);
    }

    public void WriteName(string userId, string name)
    {
        DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userId).Child(DatabaseConstants.NameTag).SetValueAsync(name);
    }

    public void WriteAvatar(string userId, int avatarIdx)
    {
        DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userId).Child(DatabaseConstants.AvatarTag).SetValueAsync(avatarIdx);
    }
}
