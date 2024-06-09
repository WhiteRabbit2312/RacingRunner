using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Back : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    public void BackButton(GameObject panel)
    {
        panel.SetActive(false);
        _mainMenu.SetActive(true);
    }
}
