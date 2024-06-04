using UnityEngine;
using UnityEngine.EventSystems;

public class SearchListItem : MonoBehaviour, IPointerClickHandler {
    
    public void LocateEstablishment() {
        AppController.Instance.Locate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        AppController.Instance.OpenRestaurantDetails();
    }
}