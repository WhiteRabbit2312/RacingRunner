using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchPanel : MonoBehaviour
{
    [SerializeField] private GameObject _signInPanel;
    [SerializeField] private GameObject _logInPanel;
    public void OpenSignInPanelButton()
    {
        _signInPanel.SetActive(true);
        _logInPanel.SetActive(false);
    }

    public void OpenLogInPanelButton()
    {
        _signInPanel.SetActive(false);
        _logInPanel.SetActive(true);
    }
}
