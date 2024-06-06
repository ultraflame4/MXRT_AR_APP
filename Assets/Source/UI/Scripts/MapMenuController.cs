using UnityEngine;

public class MapMenuController : MonoBehaviour
{
    public IconButton btnAR;
    public GameObject mapMenuPanel;
    public GameObject twoDMap;


    private void Start()
    {
        btnAR.Clicked += OnARClick;

    }

    private void OnARClick(IconButton button)
    {
        twoDMap.SetActive(!button.active);
    }

}