using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using Firebase.Database;
using Firebase.Extensions;
using UnityEngine.SceneManagement;
    
public class Registration : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private TMP_InputField _passwordField;

    [SerializeField] private Button _registrationButton;

    private SetUserData _userInDatabase;
    private RegistrationFields _registrationFields;
    private Hints _hints;

    private readonly int _startPlayerTime = 0;

    void Start()
    {
        _registrationButton.onClick.AddListener(HandRegistrationStateClicked);
        _hints = GetComponent<Hints>();
        _userInDatabase = GetComponent<SetUserData>();
        _registrationFields = GetComponent<RegistrationFields>();
    }

    private void HandRegistrationStateClicked()
    {
        if (_registrationFields.CheckAuthorization())
        {
            //Debug.LogWarning("Start coroutine");
            StartCoroutine(CheckName());
        }
            
    }

    private IEnumerator TryRegistration(string email, string password)
    {
        var auth = AuthorizationManager.Instance.Auth;


        var registrationTask = auth.CreateUserWithEmailAndPasswordAsync(email, password).ContinueWithOnMainThread(task =>
        {
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

            AddUserDataToDatabase();
            EnterMenuScene();
            /*
            // Firebase user has been created.
            Firebase.Auth.AuthResult result = task.Result;
            Debug.LogFormat("Firebase user created successfully: {0} ({1})",
                result.User.DisplayName, result.User.UserId);*/

        });
        yield return new WaitUntil(predicate: () => registrationTask.IsCompleted);

        

        
    }

    private void AddUserDataToDatabase()
    {
        string userId = AuthorizationManager.Instance.Auth.CurrentUser.UserId;
        _userInDatabase.WriteNewUser(userId);
        _userInDatabase.WriteName(userId, _nameField.text);
        _userInDatabase.WriteScore(userId, _startPlayerTime);
        _userInDatabase.WriteAvatar(userId, DatabaseConstants.DefaultAvatarID);
    }

    private void EnterMenuScene()
    {
        SceneManager.LoadScene(DatabaseConstants.MenuSceneID);
        Destroy(this);
    }

    private IEnumerator CheckName()
    {

        if (DatabaseManager.Instance.Reference == null)
        {
            Debug.LogError("DatabaseError is null");
        }

        var task = DatabaseManager.Instance.Reference.Child(DatabaseConstants.UserTag).GetValueAsync();
        yield return new WaitUntil(() => task.IsCompleted);

        if (task.IsFaulted || task.IsCanceled)
        {
            Debug.LogError("Error when getting highscore");
        }
        else
        {
            DataSnapshot snapshot = task.Result;
            bool canRegister = true;

            foreach (var item in snapshot.Children)
            {
                if (_nameField.text == item.Child(DatabaseConstants.NameTag).Value.ToString())
                {
                    canRegister = false;
                    _hints.NameExists();
                    yield return null;
                }

            }

            if(canRegister)
                StartCoroutine(TryRegistration(_emailField.text, _passwordField.text));


        }
    }

    private void OnDestroy()
    {
        _registrationButton.onClick.RemoveListener(HandRegistrationStateClicked);
    }

}
