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
            Debug.LogError("QueryListItem has no data!");
            return;
        }
        title.text = data.name;
        latestUpdate.text = data.desc;
        type.text = data.type;
    }

    
}