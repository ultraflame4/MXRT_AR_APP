using UnityEngine;
using UnityEngine.EventSystems;

public class ClosePopupMenu : MonoBehaviour, IPointerClickHandler
{
    public bool closeOnClicked = true;
    public PopupMenuController menu;

    public void Close(){
        menu.Close();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!closeOnClicked) return;
        Close();
    }
}