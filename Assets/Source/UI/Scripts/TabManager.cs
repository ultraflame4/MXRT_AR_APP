using System;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [Serializable]
    public class TabData
    {
        public GameObject tabPanel;
        public IconButton activator;
        public bool requireAuth = false;

        public void SetActive(bool active)
        {
            if (tabPanel != null) tabPanel.SetActive(active);
            activator.SetActive(active);
        }

        public bool HasButton(IconButton button)
        {
            return activator == button;
        }
    }
    public TabData[] tabs;
    public TabData current_tab {get; private set;}

    public delegate void TabChangeRequestedHandler(TabData tab, bool isSameTab);
    public event TabChangeRequestedHandler TabChanged;

    private void Start()
    {
        foreach (var tab in tabs)
        {
            var button = tab.activator;
            button.override_click_behavior = true;
            button.Clicked += OnTabClicked;
            tab.SetActive(false);
        }

        current_tab = tabs[0];
        ReloadTabs();
    }

    public void ReloadTabs()
    {
        foreach (var tab in tabs)
        {
            var disabled = tab.requireAuth && AppController.Instance.authState != AppController.LoginState.LOGGED_IN;
            tab.activator.SetDisabled(disabled);
            tab.SetActive(false);
        }
        current_tab.SetActive(true);
    }


    void OnTabClicked(IconButton clickedButton)
    {
        if (clickedButton.disabled) return;
        TabData old_tab = current_tab;
        foreach (var tab in tabs)
        {
            if (tab.HasButton(clickedButton))
            {
                current_tab = tab;
                tab.SetActive(true);
                continue;
            }
            tab.SetActive(false);
        }
        TabChanged?.Invoke(current_tab, old_tab == current_tab);
    }
}