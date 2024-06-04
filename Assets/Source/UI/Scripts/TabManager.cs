using System;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    [Serializable]
    public class TabData
    {
        public GameObject tabPanel;
        public IconButton activator;

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
        tabs[0].SetActive(true);
    }

    public void ReloadTabs()
    {
        foreach (var tab in tabs)
        {
            tab.SetActive(false);
        }
        current_tab.SetActive(true);
    }


    void OnTabClicked(IconButton clickedButton)
    {
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
    }
}