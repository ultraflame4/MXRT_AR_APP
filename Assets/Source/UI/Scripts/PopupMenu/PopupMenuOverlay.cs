using UnityEngine;
using UnityEngine.EventSystems;

public class PopupMenuOverlay : MonoBehaviour, IPointerClickHandler{
    public PopupMenuManager manager;

    public void OnPointerClick(PointerEventData eventData)
    {
        manager.CloseAllMenu();
    }
}