using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Fusion;
using Firebase.Database;
using TMPro;

public class GetUserAccountData : NetworkBehaviour
{
    [SerializeField] private Image _avatarImg;
    [SerializeField] private Sprite[] _avatarSprites;
    [SerializeField] private TextMeshProUGUI _nameText;
    [SerializeField] private GameObject _countDownPanel;

    [SerializeField] private GameObject _showPlayersPanel;
    [SerializeField] private GameObject _waitingPanel;

    private readonly float _showUsersTime = 5f;
    private bool _startCountDown = false;

    public bool StartCountDown
    {

        get
        {
            return _startCountDown;
        }

        set { }
    }

    public void StartGame()
    {
        _showPlayersPanel.SetActive(true);
        _waitingPanel.SetActive(false);

        StartCoroutine(ShowUsers());
        StartCoroutine(GetUserAvatarCoroutine());
        StartCoroutine(GetUserNameCoroutine());
    }

    private IEnumerator GetUserAvatarCoroutine()
    {
        Debug.LogError("");
        string userID = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userID).Child(DatabaseConstants.AvatarTag).GetValueAsync();

        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error when getting avatar");
        }

        else
        {
            Debug.LogError("task: " + task);
            DataSnapshot snapshot = task.Result;
            Debug.LogError("snapshot: " + snapshot);
            int avatarId = int.Parse(snapshot.Value.ToString());
            _avatarImg.sprite = _avatarSprites[avatarId];
        }
    }
    private IEnumerator GetUserNameCoroutine()
    {
        string userID = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).Child(userID).Child(DatabaseConstants.NameTag).GetValueAsync();

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

    private IEnumerator ShowUsers()
    {
        yield return new WaitForSeconds(_showUsersTime);
        _startCountDown = true;
        _countDownPanel.SetActive(true);
        _showPlayersPanel.SetActive(false);
    }
}
