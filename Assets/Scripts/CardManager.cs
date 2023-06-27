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

    public List<Card> player1Hand = new List<Card>();
    public List<Card> player2Hand = new List<Card>();

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
    }

    public void DrawTreasureCard(int player)
    {
        if (player == 1 || player == 2)
        {
            if (treasureDeck[treasureDeck.Count - 1].cardName == "WatersRise")
            {
                WatersRiseDrawn();
                treasureDeck.Remove(treasureDeck[treasureDeck.Count - 1]);

                treasureDiscard.Add(treasureDeck[treasureDeck.Count - 1]);
                //var currentCard = Instantiate(cardPrefab, new Vector3(0, 0, 0), quaternion.identity);
                //currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
            }
            else
            {
                if (player == 1)
                {
                    var currentCard = Instantiate(cardPrefab, new Vector3(-1, -1, -1), quaternion.identity);
                    currentCard.gameManager = gameManager;
                    currentCard.cardManager = this;
                    currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    player1Hand.Add(currentCard);

                    for (int i = 0; i < player1Hand.Count; i++)
                    {
                        if (i == 0)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-4.3f, -0.1f, 0);
                        }
                        if (i == 1)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-2.86f, -0.1f, 0);
                        }
                        if (i == 2)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-1.43f, -0.1f, 0);
                        }
                        if (i == 3)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(0f, -0.1f, 0);
                        }
                        if (i == 4)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-4.3f, 2f, 0);
                        }
                        if (i == 5)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-2.86f, 2f, 0);
                        }
                        if (i == 6)
                        {
                            player1Hand[i].gameObject.transform.position = new Vector3(-1.43f, 2f, 0);
                        }
                    }
                }
                else if (player == 2)
                {
                    var currentCard = Instantiate(cardPrefab, new Vector3(-1, -1, -1), quaternion.identity);
                    currentCard.gameManager = gameManager;
                    currentCard.cardManager = this;
                    currentCard.cardInfo = treasureDeck[treasureDeck.Count - 1];
                    player2Hand.Add(currentCard);

                    for (int i = 0; i < player2Hand.Count; i++)
                    {
                        if (i == 0)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(11.8f, -0.1f, 0);
                        }
                        if (i == 1)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(10.36f, -0.1f, 0);
                        }
                        if (i == 2)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(8.93f, -0.1f, 0);
                        }
                        if (i == 3)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(7.5f, -0.1f, 0);
                        }
                        if (i == 4)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(11.8f, 2f, 0);
                        }
                        if (i == 5)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(10.36f, 2f, 0);
                        }
                        if (i == 6)
                        {
                            player2Hand[i].gameObject.transform.position = new Vector3(8.93f, 2f, 0);
                        }
                    }
                }

                tCardFlip.sprite.sprite = treasureDeck[treasureDeck.Count - 1].Default;
                tCardFlip.animateTreasureFlip();
                treasureDeck.RemoveAt(treasureDeck.Count - 1);
            }
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

    public void RemoveFromHand(Card clickedCard, int player)
    {
        treasureDiscard.Add(clickedCard.cardInfo);
        if (player == 1)
        {
            
            player1Hand.Remove(clickedCard);
        }
        else if(player == 2)
        {
           
            player2Hand.Remove(clickedCard);
        }
        //gameManager.UpdateHand(clickedCard, player);
    }


}
