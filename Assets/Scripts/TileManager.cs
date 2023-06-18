using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class TileManager : MonoBehaviour
{
    [FormerlySerializedAs("Prefab")]
    [SerializeField]
    private Tile tilePrefab;

    public List<Tile> deckTiles = new List<Tile>();
    [SerializeField] private List<TileInfo> deck = new List<TileInfo>();
    [SerializeField] private GameManager gameManager;
    [SerializeField] private Transform cam;

    public List<Tile> tiles;
    private float row, column;

    public void ShuffleTileList()
    {
        int numberOfTiles = deck.Count;
        for (int i = 0; i < numberOfTiles; i++)
        {
            int firstRandInt = Random.Range(0, numberOfTiles);
            int secondRandInt = Random.Range(0, numberOfTiles);
            SwapTileListPos(deck, firstRandInt, secondRandInt);
        }
    }

    private void SwapTileListPos(List<TileInfo> list, int a, int b)
    {
        TileInfo elementA = list[a];
        TileInfo elementB = list[b];

        list[a] = elementB;
        list[b] = elementA;
    }

    public void DisplayTiles()
    {
        deckTiles = new List<Tile>();
        int placedTilesCounter = 0;
        row = 0;

        cam.transform.position = new Vector3(3.75f, 3.75f, -1f);
        while (row < 6)
        {
            column = 0;
            if ((row == 0) || (row == 5))
            {
                column += 2;
                for (int i = 0; i < 2; i++)
                {
                    var currentTile = Instantiate(tilePrefab, new Vector3((float)(column * 1.5), (float)(row * 1.5)), quaternion.identity);   //spawning tile prefab
                    currentTile.tileInfo = deck[placedTilesCounter]; //assigning tileinfo to tile prefab 
                    currentTile.transform.localScale = new Vector3(0.5f, 0.5f, 1f); // Adjust the scale as per your needs
                    deckTiles.Add(currentTile);
                    placedTilesCounter += 1;
                    column += 1;
                }
            }

            if ((row == 1) || (row == 4))
            {
                column += 1;
                for (int i = 0; i < 4; i++)
                {
                    var currentTile = Instantiate(tilePrefab, new Vector3((float)(column * 1.5), (float)(row * 1.5)), quaternion.identity);   //spawning tile prefab
                    currentTile.tileInfo = deck[placedTilesCounter]; //assigning tileinfo to tile prefab 
                    currentTile.transform.localScale = new Vector3(0.5f, 0.5f, 1f); // Adjust the scale as per your needs
                    deckTiles.Add(currentTile);
                    placedTilesCounter += 1;
                    column += 1;
                }
            }

            if ((row == 2) || (row == 3))
            {
                for (column = 0; column < 6; column++)
                {
                    var currentTile = Instantiate(tilePrefab, new Vector3((float)(column * 1.5), (float)(row * 1.5)), quaternion.identity);   //spawning tile prefab
                    currentTile.tileInfo = deck[placedTilesCounter]; //assigning tileinfo to tile prefab 
                    currentTile.transform.localScale = new Vector3(0.5f, 0.5f, 1f); // Adjust the scale as per your needs
                    deckTiles.Add(currentTile);
                    placedTilesCounter += 1;
                }
            }

            row += 1;
        }
    }

    public void DeleteTiles()
    {
        foreach (var tile in deckTiles)
        {
            Destroy(tile.gameObject);
        }
    }
}
