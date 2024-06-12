using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Firebase.Database;

public class DatabaseManager : MonoBehaviour
{
    private static DatabaseManager _instance;

    public static DatabaseManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private DatabaseReference _reference;

    public DatabaseReference Reference
    {
        get
        {
            return _reference;
        }


    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        _reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (_instance == null)
        {
            _instance = this;
        }
    }
}
