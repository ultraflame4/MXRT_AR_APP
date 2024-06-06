using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class PopupMenuManager : MonoBehaviour
{

    public Image overlay;
    public GameObject container;
    public PopupMenuController[] menus;

    private void Start()
    {
        overlay.gameObject.SetActive(false);
        foreach (var menu in menus)
        {
            menu.manager = this;
            menu.gameObject.SetActive(false);
        }
        container.SetActive(false);
    }

    private void DisableAllMenu()
    {
        foreach (var m in menus)
        {
            m.gameObject.SetActive(false);
        }
    }

    public void ShowMenu(PopupMenuController menu)
    {
        DisableAllMenu();
        container.SetActive(true);
        overlay.gameObject.SetActive(true);
        menu.gameObject.SetActive(true);
    }

    public void CloseAllMenu()
    {
        DisableAllMenu();
        container.SetActive(false);
        overlay.gameObject.SetActive(false);
        if (AppController.Instance.searchMenu.searchMenuState == SearchMenuController.SearchMenuState.Open){
            EventSystem.current.SetSelectedGameObject(AppController.Instance.searchMenu.gameObject);
        }
    }

    internal void Close(PopupMenuController popupMenuController)
    {
        CloseAllMenu();
    }
}