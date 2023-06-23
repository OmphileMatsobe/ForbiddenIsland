using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TileManager tileManager;
    [SerializeField] private Tile tileStart;
    [SerializeField] private CardManager cardManager;

    private void Start()
    {
        StartButtonClicked();
    }
    public void StartButtonClicked()
    {
        tileManager.DeleteTiles();
        tileManager.ShuffleTileList();
        tileManager.DisplayTiles();
        cardManager.GenerateFloodDeck();
        cardManager.GenerateTreasureDeck();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Debug.Log("pressed");
            cardManager.DrawFloodCard();
        }
    }
}