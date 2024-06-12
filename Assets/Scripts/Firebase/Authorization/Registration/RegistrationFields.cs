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

    

    private void Awake()
    {
        _hints = GetComponent<Hints>();
    }

    public bool CheckAuthorization()
    {
        
        if (IsEmailValid() && CheckPasswordLength() && IsPasswordsMatch())
        {
            Debug.LogWarning("Check auth");
            return true;
        }

        else
        {
            return false;
        }

    }

    private bool IsEmailValid()
    {

        if (Regex.IsMatch(_emailField.text, EMAIL_PATTERN))
        {
            Debug.LogWarning("Verify email");
            return true;
        }

        else
        {
            Debug.LogWarning("Wrong email");
            _hints.SymbolEmailWrong();
            return false;
        }

    }

    private bool IsPasswordsMatch()
    {
        
        if (!string.IsNullOrEmpty(_verifyPasswordField.text) && _passwordField.text == _verifyPasswordField.text)
        {
            Debug.LogWarning("Check passwords");
            return true;
        }

        else
        {
            _hints.SymbolPasswordWrong();
            return false;
        }
    }

    private bool CheckPasswordLength()
    {
        
        if (_passwordField.text.Length >= DatabaseConstants.MinPasswordLength 
            && _passwordField.text.Length <= DatabaseConstants.MaxPasswordLength)
        {

            Debug.LogWarning("Check length");
            
            return true;
        }

        else
        {
            _hints.PasswordLengthWrong();
            return true;
        }
    }
}
