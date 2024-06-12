using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private Button _logInButton;
    
    private Hints _hints;


    private void Awake()
    {
        int silentId = PlayerPrefs.GetInt(DatabaseConstants.SilentAuthTag);

        if (silentId == DatabaseConstants.SilentAuthId)
        {
            EnterMenuScene();
        }
    }

    void Start()
    {
        _hints = GetComponent<Hints>();
        _logInButton.onClick.AddListener(HandRegistrationStateClicked);
    }

    private void HandRegistrationStateClicked()
    {
        StartCoroutine(routine: CheckLogin(_emailField.text, _passwordField.text));
    }

    private IEnumerator CheckLogin(string email, string password)
    {
        var auth = AuthorizationManager.Instance.Auth;

        var logInTask = auth.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync was canceled.");
                _hints.EmailOrPasswordWrong();
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                _hints.EmailOrPasswordWrong();
                return;
            }

        });

        yield return new WaitUntil(predicate: () => logInTask.IsCompleted);
        EnterMenuScene();
        EnableSilentAuthentification();
    }

    private void EnterMenuScene()
    {
        SceneManager.LoadScene(DatabaseConstants.MenuSceneID);
    }

    private void EnableSilentAuthentification()
    {
        PlayerPrefs.SetInt(DatabaseConstants.SilentAuthTag, DatabaseConstants.SilentAuthId);
    }
}
