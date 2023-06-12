using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class deck : MonoBehaviour
{
    public static List<cardInfo> Deck = new List<cardInfo>();
    public static List<cardInfo> DeckRecord = new List<cardInfo>();

    private void Start()
    {

        //This assignes all the cards in our Database to the Deck

        for (int i = 0; i < Deck.Count; i++)
        {
            Deck[i] = dataBase.cards[i];
        }

        shuffle();
    }

    //This functions is used to shuffle the cards in the Deck
    //The function assignes the i'th item of the list to the record list (DeckRecord) with index 0
    //A random number is generated and used an index. This random list item is then reassigned with the DeckRecord List item
    // This list is yet to be updated, i am still tryin to figure out how i can avoid the deck having the same cards multiple times.
    public void shuffle()
    {
        for (int i = 0; i < Deck.Count;i++)
        {
            DeckRecord[0] = Deck[i];

            Deck[Random.Range(i, Deck.Count)] = DeckRecord[0];
        }
    }
}
