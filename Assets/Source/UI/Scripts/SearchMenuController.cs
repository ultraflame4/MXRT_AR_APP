using UnityEngine;

public class SearchMenuController : MonoBehaviour
{
    public enum SearchMenuState
    {
        Open,
        Partial,
        Close
    }
    public RectTransform searchMenu;
    public RectTransform searchMenuBar;
    public RectTransform bottomNavBar;
    [Range(0, 1)]
    public float open_y_pos = 0;
    [Range(0, 1)]
    public float partial_y_pos = 0;
    [Range(0, 1)]
    public float hidden_y_pos = 0;
    public SearchMenuState searchMenuState;
    public float transitionSpeed = 10f;
    private Vector3 desiredAnchoredPosition;
    public void UpdatePosition()
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
            case SearchMenuState.Close:
                yoffset = searchMenu.rect.height * hidden_y_pos;
                break;
        }

        desiredAnchoredPosition = new Vector2(searchMenu.anchoredPosition.x, yoffset);
        if (!Application.isPlaying){
            searchMenu.anchoredPosition =desiredAnchoredPosition;
        }

    }

    private void Update() {
        searchMenu.anchoredPosition = Vector2.Lerp(searchMenu.anchoredPosition, desiredAnchoredPosition, Time.deltaTime * transitionSpeed);
    }

    private void OnValidate()
    {
        UpdatePosition();
    }
}