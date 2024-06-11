using UnityEngine.SceneManagement;
using Firebase.Auth;
using UnityEngine;

public class Logout : MonoBehaviour
{
    private int _logoutIdx = 1;
    private int _sceneIdx = 0;

    public void LogoutButton()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        PlayerPrefs.SetInt("Silent", _logoutIdx);
        SceneManager.LoadScene(_sceneIdx);
    }
}
