using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class Avatar : NetworkBehaviour
{
    private Sprite[] _avatarSprites;
    private Image _avatarImg;
    private int _avatarIdx;

    public void SelectAvatar(int avatarIdx)
    {
        _avatarIdx = avatarIdx;
    }

    public void SetAvatar()
    {
        string userId = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        DatabaseManager.Instance.Reference.Child("User").Child(userId).Child("avatar").SetValueAsync(_avatarIdx);

        _avatarImg.sprite = _avatarSprites[_avatarIdx];
    }
}
