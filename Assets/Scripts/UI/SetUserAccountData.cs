using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using Firebase.Database;
using TMPro;

public class SetUserAccountData : NetworkBehaviour
{
    [SerializeField] private Image _avatarImg;
    [SerializeField] private Sprite[] _avatarSprites;
    [SerializeField] private TextMeshProUGUI _nameText;

    public override void Spawned()
    {
        StartCoroutine(GetUserAvatarCoroutine());
        StartCoroutine(GetUserNameCoroutine());
    }

    private IEnumerator GetUserAvatarCoroutine()
    {
        var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(DatabaseConstants.AvatarTag).GetValueAsync();


        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error when getting avatar");
        }

        else
        {
            DataSnapshot snapshot = task.Result;
            int avatarID = (int)snapshot.Value;
            _avatarImg.sprite = _avatarSprites[avatarID];
        }
    }
    private IEnumerator GetUserNameCoroutine()
    {
        var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(DatabaseConstants.NameTag).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);
        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error when getting name");
        }

        else
        {
            DataSnapshot snapshot = task.Result;
            _nameText.text = snapshot.Value.ToString();
        }

    }
}
