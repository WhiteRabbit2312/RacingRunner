using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hints : MonoBehaviour
{
    [SerializeField] private GameObject _nameExistingPanel;
    [SerializeField] private GameObject _wrongSymbolNumberPanel;
    [SerializeField] private GameObject _wrongEmailPanel;
    [SerializeField] private GameObject _wrongLengthPasswordPanel;

    public void SymbolPasswordWrong()
    {
        _wrongSymbolNumberPanel.SetActive(true);
    }

    public void PasswordLengthWrong()
    {
        _wrongLengthPasswordPanel.SetActive(true);
    }

    public void NameExists()
    {
        _nameExistingPanel.SetActive(true);
    }

    public void SymbolEmailWrong()
    {
        _wrongEmailPanel.SetActive(true);
    }

}
