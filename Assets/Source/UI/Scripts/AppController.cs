using System;
using UnityEngine;



public class AppController : MonoBehaviour
{
    public enum LoginState
    {
        GUEST,
        LOGGED_IN,
    }
    public LoginState authState { get; private set; } = LoginState.GUEST;
    public static AppController Instance => _instance;


    public MapMenuController mapMenuController;
    public TabManager tabManager;
    public SearchMenuController searchMenu;

    private static AppController _instance;
    

    private void Awake()
    {
        if (_instance != null)
        {
            Debug.LogWarning($"AppController ({_instance}) already exists! This will cause problems!");
        }
        _instance = this;
    }

    private void Start() {
        tabManager.TabChanged += OnTabChangeRequested;
    }

    private void OnTabChangeRequested(TabManager.TabData tab, bool isSameTab)
    {
        searchMenu.Close();
        CloseMap();
    }

    public void Login()
    {
        authState = LoginState.LOGGED_IN;
        tabManager.ReloadTabs();
    }


    public void Locate()
    {
        OpenMap();
        searchMenu.HidePartial();
    }

    public void OpenMap()
    {
        mapMenuController.gameObject.SetActive(true);
    }
    
    public void CloseMap()
    {
        mapMenuController.gameObject.SetActive(false);
    }
    
    
}