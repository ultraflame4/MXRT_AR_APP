using UnityEngine;

public class LocationManager : MonoBehaviour {
    public Transform hotel;
    public Transform street;
    public InterestPointManager interestPointManager;
    public void OpenHotel() {
        hotel.gameObject.SetActive(true);
        street.gameObject.SetActive(false);
        interestPointManager.ClearFocus();
    }

    public void OpenStreet() {
        hotel.gameObject.SetActive(false);
        street.gameObject.SetActive(true);
        interestPointManager.ClearFocus();
    }
}