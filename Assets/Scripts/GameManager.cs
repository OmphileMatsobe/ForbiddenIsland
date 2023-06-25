using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private CardManager cardManager;
<<<<<<< HEAD
    [SerializeField] private PlayerManager playerManager;

    public int playerTurn = 1;
    bool gameStarted = false;
    bool setUpCompleted = false;

=======

    private void Start()
    {
        StartButtonClicked();
    }
>>>>>>> fd493787c51df0b83ab9ef07d30d183c97bc6047
    public void StartButtonClicked()
    {
        tileManager.DeleteTiles();
        cardManager.ResetCards();
        tileManager.ShuffleTileList();
        tileManager.DisplayTiles();
        cardManager.GenerateFloodDeck();
        cardManager.GenerateTreasureDeck();
<<<<<<< HEAD
        gameStarted = true;
    }
    
    public void SetUp()
    {
        cardManager.SixTilesFlooded();
        cardManager.TreasureHandout();
        setUpCompleted = true;
=======
        
>>>>>>> fd493787c51df0b83ab9ef07d30d183c97bc6047
    }

    // Update is called once per frame
    void Update()
    {
        // if player 1 turn , else player 2 turn else startup function
        if (Input.GetKeyDown(KeyCode.F))
        {
            //Debug.Log("pressed");
            cardManager.DrawFloodCard();
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            cardManager.WatersRiseDrawn();
        }
        if(cardManager.treasureDeck.Count == 0)
        {
            cardManager.ShuffleCardDeck(cardManager.treasureDeck);
        }
        if (cardManager.floodDeck.Count == 0)
        {
            cardManager.ShuffleCardDeck(cardManager.floodDeck);
        }

        if (gameStarted && setUpCompleted)
        {
            if (playerTurn == 1)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    cardManager.DrawTreasureCard(1);
                    playerTurn = 2;
                }
            }
            else if (playerTurn == 2)
            {
                if (Input.GetKeyDown(KeyCode.T))
                {
                    cardManager.DrawTreasureCard(2);
                    playerTurn = 1;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            cardManager.RemoveFromHand();
        }

    }
}