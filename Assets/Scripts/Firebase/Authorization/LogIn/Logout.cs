using UnityEngine.SceneManagement;
using Firebase.Auth;
using UnityEngine;

public class Logout : MonoBehaviour
{
    public void LogoutButton()
    {
        FirebaseAuth.DefaultInstance.SignOut();
        PlayerPrefs.SetInt(DatabaseConstants.SilentAuthTag, DatabaseConstants.LogoutId);
        SceneManager.LoadScene(DatabaseConstants.AuthScene);
    }
}
