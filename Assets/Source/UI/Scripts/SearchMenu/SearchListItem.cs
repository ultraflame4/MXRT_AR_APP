using UnityEngine;
using UnityEngine.EventSystems;

public class SearchListItem : MonoBehaviour
{

    public EstablishmentData restaurantData = new();

    public void LocateEstablishment()
    {
        AppController.Instance.LocateOnMap(restaurantData);
    }

    public void OpenDetails()
    {
        AppController.Instance.OpenRestaurantDetails();
    }
}