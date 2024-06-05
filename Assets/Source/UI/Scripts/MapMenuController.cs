using UnityEngine;

public class MapMenuController : MonoBehaviour {
    public IconButton btnAR;
    public GameObject mapMenuPanel;
    public GameObject background;

    private void OnEnable() {
        background.SetActive(false);
    }
    
    private void OnDisable() {
        background.SetActive(true);
    }
}