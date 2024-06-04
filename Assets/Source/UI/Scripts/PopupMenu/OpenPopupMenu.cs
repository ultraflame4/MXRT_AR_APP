using UnityEngine;
using UnityEngine.EventSystems;

public class OpenPopupMenu : MonoBehaviour, IPointerClickHandler
{
    public bool openOnClicked = true;
    public PopupMenuController menu;

    public void Open(){
        menu.Show();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (!openOnClicked) return;
        Open();
    }
}