using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text.RegularExpressions;

public class RegistrationFields : MonoBehaviour
{
    [SerializeField] private TMP_InputField _emailField;
    [SerializeField] private TMP_InputField _nameField;
    [SerializeField] private TMP_InputField _passwordField;
    [SerializeField] private TMP_InputField _verifyPasswordField;

    private Hints _hints;

    public const string EMAIL_PATTERN = @"^(([\w-]+\.)+[\w-]+|([a-zA-Z]{1}|[\w-]{2,}))@"
   + @"((([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\."
   + @"([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])\.([0-1]?[0-9]{1,2}|25[0-5]|2[0-4][0-9])){1}|"
   + @"([a-zA-Z]+[\w-]+\.)+[a-zA-Z]{2,4})$";

    private const int MinPasswordLength = 6;
    private const int MaxPasswordLength = 10;

    private void Awake()
    {
        _hints = GetComponent<Hints>();
    }

    public bool CheckAuthorization()
    {
        if(IsEmailValid() && IsPasswordsMatch() && CheckPasswordLength())
        {
            return true;
        }

        else
        {
            return false;
        }

    }

    private bool IsEmailValid()
    {
        if (!string.IsNullOrEmpty(_emailField.text))
        {
            return Regex.IsMatch(_emailField.text, EMAIL_PATTERN);
        }
        else
        {
            _hints.SymbolEmailWrong();
            return false;
        }
    }

    private bool IsPasswordsMatch()
    {
        if (!string.IsNullOrEmpty(_verifyPasswordField.text) && _passwordField.text != _verifyPasswordField.text)
        {
            _hints.SymbolPasswordWrong();
            return false;
        }

        else
        {
            return true;
        }
    }

    private bool CheckPasswordLength()
    {
        if (_passwordField.text.Length < MinPasswordLength && _passwordField.text.Length > MaxPasswordLength)
        {
            _hints.PasswordLengthWrong();
            return false;
        }

        else
        {
            return true;
        }
    }
}
