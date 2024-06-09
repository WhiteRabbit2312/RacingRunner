using UnityEngine.SceneManagement;
using Firebase.Auth;
using UnityEngine;

public class Logout : MonoBehaviour
{
    private int _logoutIdx = 0;
    private int _sceneIdx = 0;

    public void OnPointerClick()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        PlayerPrefs.SetInt("Log", _logoutIdx);
        SceneManager.LoadScene(_sceneIdx);
    }
}
