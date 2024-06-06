using UnityEngine;

public class RestaurantDetailsMenuController : MonoBehaviour
{
    public PopupMenuController popupMenuController;
    public InterestPointData currentRestaurant;
    public void Open()
    {
        popupMenuController.Show();
    }
    public void Close()
    {
        popupMenuController.Close();
    }


    public void Locate()
    {
        AppController.Instance.LocateOnMap(currentRestaurant);
        Close();
    }
}