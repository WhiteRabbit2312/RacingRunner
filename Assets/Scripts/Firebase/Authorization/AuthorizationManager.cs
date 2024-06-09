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
        get;
        set;
    }

    private void Awake()
    {
        _auth = FirebaseAuth.DefaultInstance;

        Auth = _auth;

        if (_instance == null)
        {
            _instance = this;

        }

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
