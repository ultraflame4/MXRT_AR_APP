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

    public void OpenYelp()
    {
        Application.OpenURL($"https://www.yelp.com/search?find_desc={currentRestaurant.name}");
    }

    public void OpenGoogle()
    {
        Application.OpenURL($"https://www.google.com/search?q={currentRestaurant.name}");
    }

    public void OpenWebsite()
    {
        Application.OpenURL(currentRestaurant.website);
    }


    public void Locate()
    {
        AppController.Instance.LocateOnMap(currentRestaurant);
        Close();
    }
}