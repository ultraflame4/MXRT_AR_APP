using UnityEngine;

public class PopupMenuController : MonoBehaviour
{
    public PopupMenuManager manager = null;



    public void Show()
    {
        if (manager == null)
        {
            Debug.LogError("No manager assigned to PopupMenuController. Is it added to the menus array in PopupMenuManager?");
            return;
        }
        manager.ShowMenu(this);
    }

    public void Close()
    {
        if (manager == null)
        {
            Debug.LogError("No manager assigned to PopupMenuController. Is it added to the menus array in PopupMenuManager?");
            return;
        }
        manager.Close(this);
    }

}