using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;
using Firebase;
using TMPro;
using UnityEngine.UI;
using Firebase.Database;

public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private TMP_InputField _passwordField;

    [SerializeField] private Button _registrationButton;

    private UserInDatabase _userInDatabase;
    private RegistrationFields _registrationFields;
    private Hints _hints;

    private int _startScore = 0;

    void Start()
    {
        _registrationButton.onClick.AddListener(HandRegistrationStateClicked);
        _hints = GetComponent<Hints>();
        _userInDatabase = GetComponent<UserInDatabase>();
    }

    private void HandRegistrationStateClicked()
    {
        if(_registrationFields.CheckAuthorization())
            StartCoroutine(TryRegistrate());
    }

    private IEnumerator CheckRegistration(string email, string password)
    {
        var auth = AuthorizationManager.Instance.Auth;

        var registrationTask = auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWith(task => {
            if (task.IsCanceled)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync was canceled.");
                return;
            }
            if (task.IsFaulted)
            {
                Debug.LogError("CreateUserWithEmailAndPasswordAsync encountered an error: " + task.Exception);
                return;
            }
            /*
            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);*/

        });

        string userId = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        _userInDatabase.WriteNewUser(userId);
        _userInDatabase.WriteName(userId, _nameField.text);
        _userInDatabase.WriteScore(userId, _startScore);

        yield return new WaitUntil(predicate: () => registrationTask.IsCompleted);
    }

    private IEnumerator TryRegistrate()
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

            foreach (var item in snapshot.Children)
            {
                if (_nameField.text == item.Child("name").Value.ToString())
                {
                    _hints.NameExists();
                    yield return null;
                }

            }

            StartCoroutine(CheckRegistration(_emailField.text, _passwordField.text));


        }
    }

    private void OnDestroy()
    {
        _registrationButton.onClick.RemoveListener(HandRegistrationStateClicked);
    }

}
