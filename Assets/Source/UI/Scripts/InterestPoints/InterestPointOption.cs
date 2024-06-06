using System;
using TMPro;
using UnityEngine;

public class InterestPointOption : MonoBehaviour
{
    public enum OptionType
    {
        Link,
        Details,
        Query,

    }

    public string link_url;

    public TextMeshProUGUI text;
    public OptionType optionType;
    public EstablishmentData establishmentData;

    public void OnClick()
    {
        switch (optionType)
        {
            case OptionType.Link:
                Application.OpenURL(link_url);
                break;
            case OptionType.Query:
                AppController.Instance.NewQuery();
                break;
            case OptionType.Details:
                AppController.Instance.restaurantDetails.currentRestaurant = establishmentData;
                AppController.Instance.OpenRestaurantDetails();
                break;
        }
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

}