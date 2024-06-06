using UnityEngine;

public class MapMenuController : MonoBehaviour
{
    public IconButton btnAR;
    public GameObject mapMenuPanel;
    public GameObject background;
    public GameObject twoDMap;


    private void Start()
    {
        btnAR.Clicked += OnARClick;

    }

    private void OnARClick(IconButton button)
    {
        twoDMap.SetActive(!button.active);
    }

    private void OnEnable()
    {
        background.SetActive(false);
    }

    private void OnDisable()
    {
        background.SetActive(true);
    }
}