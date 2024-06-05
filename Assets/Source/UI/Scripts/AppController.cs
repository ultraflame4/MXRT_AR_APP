using System;
using UnityEngine;
using UnityEngine.EventSystems;



public class AppController : MonoBehaviour
{
    public enum LoginState
    {
        GUEST,
        LOGGED_IN,
    }
    [field: SerializeField]
    public LoginState authState { get; private set; } = LoginState.GUEST;
    public static AppController Instance => _instance;

    public PopupMenuManager popupMenuManager;
    public RestaurantDetailsMenuController restaurantDetails;
    public MapMenuController mapMenuController;
    public TabManager tabManager;
    public SearchMenuController searchMenu;

    private static AppController _instance;
    public bool isMapOpen => mapMenuController.gameObject.activeSelf;
    public bool hasPopupOpen => popupMenuManager.overlay.gameObject.activeSelf;

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

        tabManager.ReloadTabs();
    }

    private void OnTabChangeRequested(TabManager.TabData tab, bool isSameTab)
    {
        CloseMap();
        searchMenu.Unfocus();
    }

    public void Login()
    {
        authState = LoginState.LOGGED_IN;
        tabManager.ReloadTabs();
    }


    public void OpenRestaurantDetails()
    {
        restaurantDetails.Open();
    }

    public void LocateOnMap(EstablishmentData restaurantData)
    {
        OpenMap();
        searchMenu.HidePartial();
    }

    public void OpenMap()
    {
        EventSystem.current.SetSelectedGameObject(mapMenuController.gameObject);
        tabManager.current_tab.tabPanel.SetActive(false);
        mapMenuController.gameObject.SetActive(true);
    }
    
    public void CloseMap()
    {
        mapMenuController.gameObject.SetActive(false);
        tabManager.current_tab.tabPanel.SetActive(true);
    }
    
    
}