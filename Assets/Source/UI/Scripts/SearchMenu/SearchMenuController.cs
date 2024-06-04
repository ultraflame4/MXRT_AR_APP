using System;
using UnityEngine;

public class SearchMenuController : MonoBehaviour
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



    }




    public void Open()
    {
        searchMenuState = SearchMenuState.Open;
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
        Close();
    }
}