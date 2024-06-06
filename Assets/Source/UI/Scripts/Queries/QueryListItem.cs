using TMPro;
using UnityEngine;

public class QueryListItem : MonoBehaviour {
    public QueriesDatabase.Query data;
    public TextMeshProUGUI title;
    public TextMeshProUGUI latestUpdate;
    public TextMeshProUGUI type;

    private void Start() {
        if (data == null)
        {
            Debug.LogWarning("QueryListItem has no data!");
            return;
        }
        title.text = data.name;
        latestUpdate.text = "Hello, this is an example response from the staff.\n- Example Staff";
        type.text = data.type;
    }

    public void Open(){
        AppController.Instance.queriesDetails.currentQuery = data;
        AppController.Instance.queriesDetails.Open();
    }
    
}