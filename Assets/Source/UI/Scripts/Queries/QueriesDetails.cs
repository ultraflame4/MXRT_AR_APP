using TMPro;
using UnityEngine;

public class QueriesDetails : MonoBehaviour
{
    public TextMeshProUGUI title;
    public TextMeshProUGUI desc;
    public PopupMenuController popupMenuController;

    public QueriesDatabase.Query currentQuery;
    public void Open()
    {
        title.text = currentQuery.name;
        desc.text = currentQuery.desc;
        popupMenuController.Show();
    }
}