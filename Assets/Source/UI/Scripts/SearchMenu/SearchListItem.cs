using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class SearchListItem : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;
    public TextMeshProUGUI rating;
    public InterestPointData data = new();
    

    private void Start() {
        title.text = data.name;
        desc.text = data.description;
        rating.text = Mathf.Round(data.rating * 5).ToString();
    }
    public void LocateEstablishment()
    {
        AppController.Instance.LocateOnMap(data);
    }

    public void OpenDetails()
    {
        AppController.Instance.restaurantDetails.currentRestaurant = data;
        AppController.Instance.OpenRestaurantDetails();
    }
}