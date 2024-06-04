using UnityEngine;

public class SearchListItem : MonoBehaviour {
    
    public void LocateEstablishment() {
        AppController.Instance.Locate();
    }
}