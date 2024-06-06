using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private Button _logInButton;

    void Start()
    {
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
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("SignInWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            /*
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("User signed in successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);*/


        });

        yield return new WaitUntil(predicate: () => logInTask.IsCompleted);
    }
}
