using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnablePanel : MonoBehaviour
{
    [SerializeField] private GameObject _mainMenu;
    public void CloseButton(GameObject panel)
    {
        panel.SetActive(false);
        _mainMenu.SetActive(true);
    }

    public void OpenButton(GameObject panel)
    {
        panel.SetActive(true);
        _mainMenu.SetActive(false);
    }
}
