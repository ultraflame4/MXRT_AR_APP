using UnityEngine;

public class QueryList : MonoBehaviour
{
    public GameObject queryListItemPrefab;
    bool changed = true;

    private void Populate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (var item in AppController.Instance.queriesDatabase.queries)
        {
            var listItem = Instantiate(queryListItemPrefab, transform).GetComponent<QueryListItem>();
            listItem.data = item;
        }
    }

    private void MarkForPopulate()
    {
        changed = true;
    }

    private void Start() {
        AppController.Instance.queriesDatabase.QueryAdded += MarkForPopulate;
    }

    private void Update() {
        if (changed)
        {
            Populate();
            changed = false;
        }
    }
}