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
        None,

    }

    public string link_url;
    public string query_type;

    public TextMeshProUGUI text;
    public OptionType optionType;
    public InterestPointData establishmentData;

    public void OnClick()
    {
        switch (optionType)
        {
            case OptionType.Link:
                Application.OpenURL(link_url);
                break;
            case OptionType.Query:
                var newQueryMenu = AppController.Instance.newQueryMenu;
                newQueryMenu.inputTitle.text = $"{text.text} : {establishmentData.name}";
                AppController.Instance.newQueryMenu.inputType.value = newQueryMenu.inputType.options.FindIndex(x => x.text == query_type);
                AppController.Instance.newQueryMenu.Show();

                break;
            case OptionType.Details:
                AppController.Instance.restaurantDetails.currentRestaurant = establishmentData;
                AppController.Instance.OpenRestaurantDetails();
                break;

            default:
                break;
        }
    }

    public void SetText(string text)
    {
        this.text.text = text;
    }

}