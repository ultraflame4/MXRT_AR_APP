using UnityEngine;
using UnityEngine.EventSystems;

public class OpenSearchMenuOnClick : MonoBehaviour, IPointerClickHandler
{
    public void OnPointerClick(PointerEventData eventData)
    {
        AppController.Instance.searchMenu.Open();
    }
}