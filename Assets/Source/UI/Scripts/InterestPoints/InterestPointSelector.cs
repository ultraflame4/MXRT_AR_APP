using UnityEngine;
using UnityEngine.UI;

public class InterestPointSelector : MonoBehaviour {
    private RectTransform rectTransform;
    public Image image;
    public float moveSpeed = 10f;
    private Vector3 targetPosition;
    private void Awake() {
        rectTransform = GetComponent<RectTransform>();
    }

    public void UpdateData(Vector3 worldPosition, float focusPercent) {
        targetPosition =  Camera.main.WorldToScreenPoint(worldPosition);
        image.fillAmount = focusPercent;
    }

    private void Update() {
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * moveSpeed);        
    }
}