using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static InterestPointData;

public class InterestPoint : MonoBehaviour {
    
    public MeshRenderer meshRenderer {get; private set;}
    public Image iconImage;
    public TextMeshProUGUI title;
    public TextMeshProUGUI rating;
    public InterestPointData establishment;
    private Material mat;


    public Sprite icon_FOOD;
    public Sprite icon_SHOPPING;
    public Sprite icon_VIEW;
    public Sprite icon_OTHER;

    private void Awake() {
        meshRenderer = GetComponent<MeshRenderer>();
        mat = new Material(meshRenderer.material);
        meshRenderer.material = mat;
    }

    public void Start() {
        UpdateDisplay();
    }

    public void UpdateDisplay(){
        if (establishment == null) return;
        title.text = establishment.name;
        rating.text = Mathf.Round(establishment.rating * 5).ToString();
        switch (establishment.type)
        {
            case InterestPointType.FOOD:
                iconImage.sprite = icon_FOOD;
                break;
            case InterestPointType.SHOPPING:
                iconImage.sprite = icon_SHOPPING;
                break;
            case InterestPointType.VIEW:
                iconImage.sprite = icon_VIEW;
                break;
            default:
                iconImage.sprite = icon_OTHER;
                break;
        }
    }
    
    private void OnValidate() {
        UpdateDisplay();
    }
}