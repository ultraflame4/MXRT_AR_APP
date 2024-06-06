using System;
using UnityEngine;
using UnityEngine.EventSystems;


public class SearchMenuController : MonoBehaviour, IPointerClickHandler
{
    public enum SearchMenuState
    {
        Open,
        Partial,
        Hidden
    }
    public RectTransform searchMenu;
    [Range(0, 1)]
    public float open_y_pos = 0;
    [Range(0, 1)]
    public float partial_y_pos = 0;
    [Range(0, 1)]
    public float hidden_y_pos = 0;
    [field: SerializeField]
    public SearchMenuState searchMenuState { get; private set; } = SearchMenuState.Hidden;
    public float transitionSpeed = 10f;
    private Vector3 desiredAnchoredPosition;

    private void UpdatePosition()
    {
        float yoffset = 0;
        switch (searchMenuState)
        {
            case SearchMenuState.Open:
                yoffset = searchMenu.rect.height * open_y_pos;
                break;
            case SearchMenuState.Partial:
                yoffset = searchMenu.rect.height * partial_y_pos;
                break;
            case SearchMenuState.Hidden:
                yoffset = searchMenu.rect.height * hidden_y_pos;
                break;
        }

        desiredAnchoredPosition = new Vector2(searchMenu.anchoredPosition.x, yoffset);
        if (!Application.isPlaying)
        {
            searchMenu.anchoredPosition = desiredAnchoredPosition;
        }

    }

    private void Update()
    {
        searchMenu.anchoredPosition = Vector2.Lerp(searchMenu.anchoredPosition, desiredAnchoredPosition, Time.deltaTime * transitionSpeed);
        var current = EventSystem.current.currentSelectedGameObject?.transform;

        // Skip if a popup is open
        if (AppController.Instance.hasPopupOpen) return;
        // Skip if the current selected object is a child of popup menu container
        if (current?.transform.IsChildOf(AppController.Instance.popupMenuManager.transform)==true) return;
        

        if (current?.IsChildOf(transform) == true)
        {
            Open();
        }
        else
        {
            Unfocus();
        }

    }




    public void Open()
    {
        if (searchMenuState == SearchMenuState.Open) return;
        searchMenuState = SearchMenuState.Open;
        EventSystem.current.SetSelectedGameObject(searchMenu.gameObject);
        UpdatePosition();
    }
    public void HidePartial()
    {
        searchMenuState = SearchMenuState.Partial;
        UpdatePosition();
    }
    public void Close()
    {
        searchMenuState = SearchMenuState.Hidden;
        UpdatePosition();
    }
    private void OnValidate()
    {
        UpdatePosition();
    }

    /// <summary>
    /// Unfocus the search menu by closing it or hiding it partially
    /// </summary>
    public void Unfocus()
    {
        if (AppController.Instance.isMapOpen)
        {
            HidePartial();
        }
        else
        {
            Close();
        }
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        Open();
        Debug.Log("Clicked on search menu");
    }
}