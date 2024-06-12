using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Auth;

public class AuthorizationManager : MonoBehaviour
{
    private static AuthorizationManager _instance;

    public static AuthorizationManager Instance
    {
        get
        {
            return _instance;
        }
    }


    private FirebaseAuth _auth;

    public FirebaseAuth Auth
    {
        get
        {
            return _auth;
        }
        
    }

    private string _userID;

    public string UserID
    {
        get
        {
            return _userID;
        }
    }

    private void Awake()
    {

        if (_instance == null)
        {
            _instance = this;

        }

        _auth = FirebaseAuth.DefaultInstance;
        _userID = _auth.CurrentUser.UserId;

    }

    private void OnDestroy()
    {
        _auth = null;

        if (_instance == this)
        {
            _instance = null;
        }
    }
}
