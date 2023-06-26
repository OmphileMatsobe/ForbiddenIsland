using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private CardManager cardManager;
    [SerializeField] private PlayerManager playerManager;
    [SerializeField] TMP_Text text;
    public Card card;

    public int playerTurn = 1;
    bool gameStarted = false;
    bool setUpCompleted = false;

    public int action, actionCounter; // checks which action can be taken

    public void Start()
    {
        StartButtonClicked();
        Invoke("SetUp", 2f);

        action = actionCounter = 0;
    }
    public void StartButtonClicked()
    {
        tileManager.DeleteTiles();
        cardManager.ResetCards();
        tileManager.ShuffleTileList();
        tileManager.DisplayTiles();
        cardManager.GenerateFloodDeck();
        cardManager.GenerateTreasureDeck();
        gameStarted = true;
    }
    
    public void SetUp()
    {
        cardManager.SixTilesFlooded();
        cardManager.TreasureHandout();
        setUpCompleted = true;
    }

    public void UpdateHand(Card clickedCard, int player)
    {
        cardManager.treasureDiscard.Add(clickedCard.cardInfo);
        cardManager.player1Hand.Remove(clickedCard);
        Destroy(clickedCard.gameObject);

        if (player == 1)
        {
            for (int i = 0; i < cardManager.player1Hand.Count; i++)
            {
                if (i == 0)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-4.3f, -0.1f, 0);
                }
                if (i == 1)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-2.86f, -0.1f, 0);
                }
                if (i == 2)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-1.43f, -0.1f, 0);
                }
                if (i == 3)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(0f, -0.1f, 0);
                }
                if (i == 4)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-4.3f, 2f, 0);
                }
                if (i == 5)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-2.86f, 2f, 0);
                }
                if (i == 6)
                {
                    cardManager.player1Hand[i].gameObject.transform.position = new Vector3(-1.43f, 2f, 0);
                }
            }
        }
        else if(player == 2)
        {
            for (int j = 0; j < cardManager.player2Hand.Count; j++)
            {
                if (j == 0)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(11.8f, -0.1f, 0);
                }
                if (j == 1)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(10.36f, -0.1f, 0);
                }
                if (j == 2)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(8.93f, -0.1f, 0);
                }
                if (j == 3)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(7.5f, -0.1f, 0);
                }
                if (j == 4)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(11.8f, 2f, 0);
                }
                if (j == 5)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(10.36f, 2f, 0);
                }
                if (j == 6)
                {
                    cardManager.player2Hand[j].gameObject.transform.position = new Vector3(8.93f, 2f, 0);
                }
            }
        }
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
            //cardManager.RemoveFromHand();
        }

        if (cardManager.player1Hand.Count == 6 || cardManager.player1Hand.Count == 7)
        {

           // handLimitCanvas.gameObject.SetActive(true);
        }
        else if (cardManager.player2Hand.Count == 6 || cardManager.player2Hand.Count == 7)
        {
            
           // handLimitCanvas.gameObject.SetActive(true);
        }
        else
        {
            
           // handLimitCanvas.gameObject.SetActive(false);
        }

    }

    /*
     * 
     * 
     * 
     * 
     */

    void checkIfMoveOne()
    {

    }

    void checkIfShoreUPOne()
    {

    }

    void checkIfGiveTreasureCardOne()
    {

    }

    void checkIfGetTreasureOne()
    {

    }

    void checkIfMoveTwo()
    {

    }

    void checkIfShoreUPTwo()
    {

    }

    void checkIfGiveTreasureCardTwo()
    {

    }

    void checkIfGetTreasureTwo()
    {

    }

    public void switchMove()
    {
        if (action == 0)
        {
            checkIfMoveOne();
        }

        else if (action == 4)
        {
            checkIfMoveTwo();
        }

        text.text = "Move";
    }

    public void switchShore()
    {
        if (action == 1)
        {
            checkIfShoreUPOne();
        }

        else if (action == 5)
        {
            checkIfShoreUPTwo();
        }

        text.text = "Shore Up";
    }

    public void switchGive()
    {
        if (action == 2)
        {
            checkIfGiveTreasureCardOne();
        }

        else if (action == 6)
        {
            checkIfGiveTreasureCardTwo();
        }

        text.text = "Give Treasure Card";
    }

    public void switchGet()
    {
        if (action == 3)
        {
            checkIfGetTreasureOne();
        }

        else if (action == 7)
        {
            checkIfGetTreasureTwo();
        }

        text.text = "Capture Treasure";
    }


}
