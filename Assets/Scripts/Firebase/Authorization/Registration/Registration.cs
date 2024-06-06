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

    private Coroutine _registrationCoroutine;
    private bool _nameExist;

    void Start()
    {
        _registrationButton.onClick.AddListener(HandRegistrationStateClicked);
    }

    private void HandRegistrationStateClicked()
    {
        _registrationCoroutine = StartCoroutine(FindName());
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

            
        });

        yield return new WaitUntil(predicate: () => registrationTask.IsCompleted);
    }

    
    private IEnumerator FindName()
    {
        _nameExist = false;
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
                    _nameExist = true;
                    yield return null;
                }

            }

            if (!_nameExist)
            {
                StartCoroutine(CheckRegistration(_emailField.text, _passwordField.text));

            }
        }
    }

}
