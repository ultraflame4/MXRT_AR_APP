using UnityEngine;

public class RestaurantDetailsMenuController : MonoBehaviour {
    public PopupMenuController popupMenuController;
    public void Open() {
        popupMenuController.Show();
    }
}