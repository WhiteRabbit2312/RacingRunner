using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;

public class ChooseAvatar : MonoBehaviour
{
    [SerializeField] private Sprite[] _avatarSprites;
    private SetUserData _setUserData;
    private int _avatarIdx;

    private void Awake()
    {
        _setUserData = gameObject.AddComponent<SetUserData>();
    }

    public void SelectAvatar(int avatarIdx)
    {
        _avatarIdx = avatarIdx;
    }

    public void SetAvatar()
    {
        string userId = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        _setUserData.WriteAvatar(userId, _avatarIdx);
    }
}
