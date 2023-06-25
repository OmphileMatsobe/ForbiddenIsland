using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<FloodCardInfo> floodCardInfo;
    public List<FloodCardInfo> floodDeck = new List<FloodCardInfo>();
    public List<FloodCardInfo> floodDiscard = new List<FloodCardInfo>();

    [SerializeField] private List<TreasureCardInfo> treasureCardInfo;
    public List<TreasureCardInfo> treasureDeck = new List<TreasureCardInfo>();
    public List<TreasureCardInfo> treasureDiscard = new List<TreasureCardInfo>();

    public List<TreasureCardInfo> player1Hand = new List<TreasureCardInfo>();
    public List<TreasureCardInfo> player2Hand = new List<TreasureCardInfo>();

    //[SerializeField] private Card cardPrefab;
    [SerializeField] TileManager tileManager;
    [SerializeField] GameManager gameManager;
    public CardFlip cardFlip;
    public FCardDiscard discardCard;
    public TCardFlip tCardFlip;
    public TCardDiscard tDiscardCard;

    public Card cardPrefab;
    public Canvas handLimitCanvas;
    public int waterLevelCounter = 2;

    public void GenerateTreasureDeck()
    {
        treasureDeck.Clear();
        for (int i = 0; i < 28; i++)
        {
            if (treasureCardInfo[i].cardName != "WatersRise")
            {
                treasureDeck.Add(treasureCardInfo[i]);
            }
        }

        ShuffleCardDeck(treasureDeck);

        // Add Waters Rise cards to the beginning of the treasure deck
        for (int i = 0; i < 28; i++)
        {
            if (treasureCardInfo[i].cardName == "WatersRise")
            {
                treasureDeck.Insert(0, treasureCardInfo[i]);
            }
        }
    }

    public void GenerateFloodDeck()
    {
        floodDeck.Clear();
        for (int i = 0; i < 24; i++)
        {
            floodDeck.Add(floodCardInfo[i]);
        }

        ShuffleCardDeck(floodDeck);
    }

    public void SixTilesFlooded()
    {
        for(int i = 0; i < 6; i++)
        {
            DrawFloodCard();
        }
    }

    public void WatersRiseDrawn()
    {
        if (floodDiscard.Count > 0)
        {
            //Debug.Log(floodDiscard.Count);
            ShuffleCardDeck(floodDiscard);
            foreach (var floodCard in floodDiscard)
            {
                floodDeck.Add(floodCard);
            }
            floodDiscard.Clear();
            waterLevelCounter++;
        }
        else
        {
            waterLevelCounter++;
            Debug.Log(waterLevelCounter);
        }
        //gameManager.waterLevel++;
    }

    public void DrawTreasureCard(int player)
    {
        if (player == 1 || player == 2)
        {
            if (treasureDeck[treasureDeck.Count - 1].cardName == "WatersRise")
            {
                WatersRiseDrawn();


                treasureDiscard.Add(treasureDeck[treasureDeck.Count - 1]);
                //var currentCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), quaternion.identity);
                //currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
            }
            else
            {
                if (player == 1)
                {
                    player1Hand.Add(treasureDeck[treasureDeck.Count - 1]);
                    int index = player1Hand.IndexOf(treasureDeck[treasureDeck.Count - 1]);
                    //Debug.Log("Index of card in player1Hand: " + index);
                    if (index == 0)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-4.3f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 1)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-2.86f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 2)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-1.43f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 3)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(0, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 4)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-4.3f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 5)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-2.86f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 6)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(-1.43f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }

                    if (player1Hand.Count > 1)
                    {
                        //tDiscardCard.sprite.sprite = treasureDiscard[player1Hand.Count - 2].Default;
                    }
                    else
                    {
                        tDiscardCard.sprite.sprite = null;
                    }
                }
                else if (player == 2)
                {
                    player2Hand.Add(treasureDeck[treasureDeck.Count - 1]);
                    int index = player2Hand.IndexOf(treasureDeck[treasureDeck.Count - 1]);
                    //Debug.Log("Index of card in player1Hand: " + index);
                    if (index == 0)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(11.8f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 1)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(10.36f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 2)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(8.93f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 3)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(7.5f, -0.1f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 4)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(12.2f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 5)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(10.36f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }
                    if (index == 6)
                    {
                        var currentCard = Instantiate(cardPrefab, new Vector3(8.93f, 2f, 0), quaternion.identity);
                        currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    }

                    if (player2Hand.Count > 1)
                    {
                        //tDiscardCard.sprite.sprite = treasureDiscard[player2Hand.Count - 2].Default;
                    }
                    else
                    {
                        tDiscardCard.sprite.sprite = null;
                    }
                }
            }

            tCardFlip.sprite.sprite = treasureDeck[treasureDeck.Count - 1].Default;
            tCardFlip.animateTreasureFlip();
            treasureDeck.RemoveAt(treasureDeck.Count - 1);
        }
    }

    public void DrawFloodCard()
    {
        foreach (var tile in tileManager.deckTiles)
        {
            if (tile.gameObject.name == floodDeck[floodDeck.Count - 1].cardName)
            {
                if (tile.CurrentState == TileInfo.State.Default)
                {
                    tile.CurrentState = TileInfo.State.Flooded;
                    floodDiscard.Add(floodDeck[floodDeck.Count - 1]);
                    break;
                }
                else
                {
                    tile.CurrentState = TileInfo.State.Sunk;
                    break;
                }
            }
        }

        if(floodDiscard.Count > 1)
        {
            discardCard.sprite.sprite = floodDiscard[floodDiscard.Count - 2].Default;
        }
        else
        {
            discardCard.sprite.sprite = null;
        }
        cardFlip.sprite.sprite = floodDeck[floodDeck.Count - 1].Default;
        cardFlip.animateFlip();
        floodDeck.RemoveAt(floodDeck.Count - 1);
    }

    public void ResetCards()
    {
        discardCard.sprite.sprite = null;
        cardFlip.sprite.sprite = null;
        floodDiscard.Clear();
    }

    public void TreasureHandout()
    {
        DrawTreasureCard(1);
        DrawTreasureCard(1);
        DrawTreasureCard(2);
        DrawTreasureCard(2);

        ShuffleCardDeck(treasureDeck);
    }
    public void ShuffleCardDeck<T>(List<T> deck)
    {
        int numberOfTiles = deck.Count;
        for (int i = 0; i < numberOfTiles; i++)
        {
            int firstRandInt = UnityEngine.Random.Range(0, numberOfTiles);
            int secondRandInt = UnityEngine.Random.Range(0, numberOfTiles);
            SwapListPositions(deck, firstRandInt, secondRandInt);
        }
    }

    private void SwapListPositions<T>(List<T> list, int a, int b)
    {
        T elementA = list[a];
        T elementB = list[b];

        list[a] = elementB;
        list[b] = elementA;
    }

    /*public void Update()
    {
        if (player1Hand.Count == 6 || player1Hand.Count == 7)
        {
            handLimitCanvas.gameObject.SetActive(true);
        }
        else if (player2Hand.Count == 6 || player2Hand.Count == 7)
        {
            handLimitCanvas.gameObject.SetActive(true);
        }
        else
        {
            handLimitCanvas.gameObject.SetActive(false);
        }
    }*/

    public void RemoveFromHand()
    {
        treasureDiscard.Add(player1Hand[0]);
        player1Hand.RemoveAt(0);
    }


}
