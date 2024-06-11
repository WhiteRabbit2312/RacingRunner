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
        get
        {
            return reference;
        }


    }

    void Awake()
    {
        DontDestroyOnLoad(this);

        reference = FirebaseDatabase.DefaultInstance.RootReference;

        if (_instance == null)
        {
            _instance = this;
        }
    }
}
