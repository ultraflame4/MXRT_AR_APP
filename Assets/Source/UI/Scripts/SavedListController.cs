using System;
using System.Linq;
using UnityEngine;

public class SavedListController : MonoBehaviour
{
    public GameObject listItemPrefab;

    public void Populate()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }

        foreach (var item in AppController.Instance.interestPointsDatabase.interestPoints.Where(x => x.saved))
        {
            var listItem = Instantiate(listItemPrefab, transform).GetComponent<SearchListItem>();
            listItem.data = item;
        }
    }

    private void Start()
    {
        AppController.Instance.tabManager.TabChanged += OnTabChanged;
        Populate();
    }

    private void OnTabChanged(TabManager.TabData data, bool isSameTab)
    {
        Populate();
    }

}