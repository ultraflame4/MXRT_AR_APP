using System;
using UnityEngine;

public class HomeMenuController : MonoBehaviour
{
    public IconButton btnAr;
    public LocationManager locationManager;

    public GameObject homeMenuContainer;

    private void Start()
    {
        btnAr.Clicked += OnArClicked;
        AppController.Instance.tabManager.TabChanged += OnTabChangeRequested;
        btnAr.SetActive(false);
        CloseAR();
    }

    private void OnTabChangeRequested(TabManager.TabData tab, bool isSameTab)
    {
        btnAr.SetActive(false);
        CloseAR();
    }

    private void OnArClicked(IconButton button)
    {
        if (button.active)
        {
            OpenAR();
        }
        else
        {
            CloseAR();
        }
    }

    private void OpenAR()
    {
        homeMenuContainer.SetActive(false);
        if (AppController.Instance.authState == AppController.LoginState.LOGGED_IN)
        {
            locationManager.OpenHotel();
        }
        else
        {
            locationManager.OpenStreet();
        }
        
    }

    private void CloseAR()
    {
        homeMenuContainer.SetActive(true);
        locationManager.OpenStreet();
        
    }

}