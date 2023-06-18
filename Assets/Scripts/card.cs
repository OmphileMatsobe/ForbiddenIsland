using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardInfo : MonoBehaviour
{
    public int id;
    public string cardName, description;
    public string action;
    public Sprite cardImage;

    //This stores all the info of the cards,, it works together with the Database and the SO.
    public cardInfo(int Id, string CardName, string Description, string Action, Sprite CardImage)
    {
        id = Id;
        cardName = CardName;
        description = Description;
        action = Action;
        cardImage = CardImage;
    }
}
