using TMPro;
using UnityEngine;

public class RestaurantDetailsMenuController : MonoBehaviour
{
    public PopupMenuController popupMenuController;
    public InterestPointData currentRestaurant;
    public TextMeshProUGUI title;
    public TextMeshProUGUI rating;
    public TextMeshProUGUI desc;
    public IconButton btnSave;


    public void Open()
    {
        title.text = currentRestaurant.name;
        rating.text = Mathf.Round(currentRestaurant.rating * 5).ToString();
        desc.text = currentRestaurant.description;
        btnSave.SetActive(currentRestaurant.saved);
        btnSave.Clicked += ToggleSave;
        popupMenuController.Show();
    }

    void ToggleSave(IconButton button)
    {
        currentRestaurant.saved = button.active;
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