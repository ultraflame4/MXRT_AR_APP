using System;

[Serializable]
public class EstablishmentData
{

    public enum EstablishmentType{
        FOOD,
        SHOPPING,
        VIEW,
        OTHER
    }

    /// <summary>
    /// The name of the restaurant.
    /// </summary>
    public string name;
    
    /// <summary>
    /// The description of the restaurant.
    /// </summary>
    public string description;

    /// <summary>
    /// The rating of the restaurant, from 0 to 1.
    /// </summary>
    public float rating;

    /// <summary>
    /// The address of the restaurant.
    /// </summary>
    public string address;

    /// <summary>
    /// The phone number of the restaurant.
    /// </summary>
    public string phone;

    /// <summary>
    /// The website of the restaurant.
    /// </summary>
    public string website;

    /// <summary>
    /// The email of the restaurant.
    /// </summary>
    public string email;

    public EstablishmentType type;

    public EstablishmentData(){
        name = "Restaurant Name";
        description = "Restaurant Description. Lorem ipsum, dolor sit amet consectetur adipisicing elit. Quisquam, quos.";
        rating = 0.5f;
        address = "Dwad Street, 1234, City, Country";
        phone = "+1234567890";
        website = "restaurant.website.com";
        email = "restaurant@emai.com";
        type = EstablishmentType.FOOD;
    }

}