using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dataBase : MonoBehaviour
{
    public static List<cardInfo> cards= new List<cardInfo>();
    public scriptableObjects[] cardInfo;
    int x;

    //this assignes all the information from the scriptable objects to the cardInfo and stores the information in the database.
    //workes like a linker, lol. 
    private void Awake()
    {
        for (x = 0; x < cardInfo.Length; x++) 
        {
            cards.Add(new cardInfo(cardInfo[x].id , cardInfo[x].cardName, cardInfo[x].description, cardInfo[x].action, Resources.Load<Sprite>(cardInfo[x].cardImageName)));
        }
    }
}
