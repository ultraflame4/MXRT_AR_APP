using UnityEngine;

public class LocationManager : MonoBehaviour {
    public Transform hotel;
    public Transform street;

    public void OpenHotel() {
        hotel.gameObject.SetActive(true);
        street.gameObject.SetActive(false);
    }

    public void OpenStreet() {
        hotel.gameObject.SetActive(false);
        street.gameObject.SetActive(true);
    }
}