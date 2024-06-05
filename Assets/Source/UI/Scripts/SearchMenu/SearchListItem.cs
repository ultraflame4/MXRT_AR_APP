using UnityEngine;
using UnityEngine.EventSystems;

public class SearchListItem : MonoBehaviour, IPointerClickHandler
{

    public RestaurantData restaurantData = new();

    public void LocateEstablishment()
    {
        AppController.Instance.LocateOnMap(restaurantData);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AppController.Instance.OpenRestaurantDetails();
    }
}