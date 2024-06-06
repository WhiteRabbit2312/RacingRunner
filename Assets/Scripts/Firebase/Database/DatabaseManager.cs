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

    private DatabaseReference reference;

    public DatabaseReference Reference
    {
        get;
        set;

    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        reference = FirebaseDatabase.DefaultInstance.RootReference;
        Reference = reference;

        if (_instance == null)
        {
            _instance = this;
        }
    }
}