using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SearchMenuClickOverlay : MonoBehaviour, IPointerClickHandler
{
    public Image raycastBlocker;
    public SearchMenuController searchMenuController;

    private void Update() {
        raycastBlocker.raycastTarget = searchMenuController.searchMenuState == SearchMenuController.SearchMenuState.Open;
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        searchMenuController.Unfocus();
    }
}