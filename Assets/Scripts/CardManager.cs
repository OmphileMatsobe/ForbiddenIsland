using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : MonoBehaviour
{
    [SerializeField] private List<FloodCardInfo> floodCardInfo;
    [SerializeField] private List<TreasureCardInfo> treasureCardInfo;
    private List<FloodCardInfo> floodDeck = new List<FloodCardInfo>();
    public List<FloodCardInfo> floodDiscard = new List<FloodCardInfo>();
    private List<TreasureCardInfo> treasureDeck = new List<TreasureCardInfo>();
    [SerializeField] private Card cardPrefab;
    [SerializeField] TileManager tileManager;

    public void GenerateTreasureDeck()
    {
        treasureDeck.Clear();
        for(int i = 0; i < 25; i++)
        {
            treasureDeck.Add(treasureCardInfo[i]);
        }

        ShuffleCardDeck(treasureDeck);
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
                    Debug.Log("Flooding" + tile.name);
                    break;
                }
                else
                {
                    tile.CurrentState = TileInfo.State.Sunk;
                    tile.gameObject.SetActive(false);
                    break;
                }
            }
        }
        floodDeck.RemoveAt(floodDeck.Count - 1);
    }

    public void ShuffleCardDeck<T>(List<T> deck)
    {
        int numberOfTiles = deck.Count;
        for (int i = 0; i < numberOfTiles; i++)
        {
            int firstRandInt = Random.Range(0, numberOfTiles);
            int secondRandInt = Random.Range(0, numberOfTiles);
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
}
