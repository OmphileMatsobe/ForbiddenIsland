using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Build.Player;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
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

    //All var related to the Pawn and the gridMarker and the Pawn-Tile movement relationship
    [SerializeField] Button Move;
    Pawn pawnIsInst;
    bool PawnInstGridOne, PawnInstGridTwo, isMovableOne, isMovableTwo;
    GameObject obj;
    GameObject objTwo;
    Vector2 transformObjOne, transformObjTwo;
    [SerializeField] float speed = 10;
    int x = 0;
    string player, pawnTwo, pawnOne, typeAdv;
    public adventureCards advCards;
    Vector2 move;
    Vector2 objectPlate = new Vector2(0, 0);

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

    /*
     *  changeColor - changes the gridMarker color
     *  gridPlateIndicate - checks which grid/Tile the pawn can move to
     *  checkMove - first checks if the mouse clicked on the tile, the calls all the abouve mentiones to check if the pawn can move to a tile.
     *  
     *  all the argumets i believe are self explanatory
     *  Return: None
     */

    public void Update()
    {
        if (Pawn.pawnExist)
        {
            obj = GameObject.Find("PlayerOne");
            objTwo = GameObject.Find("PlayerTwo");
            checkMove(Pawn.pawnExist);
        }

        if (gameManager.action == 0)
        {
            player = "One";
        }
        else if (gameManager.action == 4)
        {
            player = "Two";
        }
        else
        {
            player = "none";
        }

        if (player == "One")
        {
            typeAdv = advCards.type;
        }
        else if (player == "Two")
        {
            typeAdv = advCards.typeTwo;
        }
        if (gameManager.action != 0 && gameManager.action != 4)
        {
            for (int j = 0; j < deckTiles.Count; j++)
            {
                deckTiles[j].transform.GetChild(1).gameObject.SetActive(false);
            }
        }
    }

    public void changeColor(int i, string cardName)
    {
        if (cardName == "Engineer")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else if (cardName == "Navigator")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
        }
        else if (cardName == "Pilot")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.blue;
        }
        else if (cardName == "Explorer")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
        else if (cardName == "Messenger")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.white;
        }
        else if (cardName == "Diver")
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
        }
        else
        {
            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.black;
        }
    }
    //This controls all the grid indicators for all the movements including the special movements

    public void gridPlateIndicate(int i, string player, string cardName)
    {
        Vector2 objectPlate = new Vector2(0, 0);
        bool check = false;

        if (player == "One")
        {
            objectPlate = obj.transform.position;
            PawnInstGridTwo = false;
            check = PawnInstGridOne;
        }
        if (player == "Two")
        {
            objectPlate = objTwo.transform.position;
            PawnInstGridOne = false;
            check = PawnInstGridTwo;
        }


        if (
            ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) && (deckTiles[i].transform.position.y == objectPlate.y) ||
             (deckTiles[i].transform.position.x - objectPlate.x == 1.5f)) && (deckTiles[i].transform.position.y == objectPlate.y)
            ||
             ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) && (deckTiles[i].transform.position.x == objectPlate.x) ||
             (deckTiles[i].transform.position.y - objectPlate.y == 1.5f)) && (deckTiles[i].transform.position.x == objectPlate.x)
            )
        {

            changeColor(i, cardName);
            isMovableOne = true;

            if (check == true)
            {
                deckTiles[i].transform.GetChild(1).gameObject.SetActive(true);
                x = 1;
                Debug.Log("X is equal to" + x);
            }

        }
        else
        {
            deckTiles[i].transform.GetChild(1).gameObject.SetActive(false);

            isMovableOne = false;
        }

        if (cardName == "Pilot")
        {
            deckTiles[i].transform.GetChild(1).gameObject.SetActive(true);
            changeColor(i, cardName);
            isMovableOne = true;
        }
        if (cardName == "Explorer")
        {
            if (
             ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) || (deckTiles[i].transform.position.x - objectPlate.x == 1.5f))
            &&
             ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) || (deckTiles[i].transform.position.y - objectPlate.y == 1.5f))
             )
            {
                deckTiles[i].transform.GetChild(1).gameObject.SetActive(true);
                changeColor(i, cardName);
                isMovableOne = true;
            }
        }
        if (cardName == "Navigator")
        {
            //I'm still yet to figure this one out
        }
        if (cardName == "Diver")
        {
            //I'm still yet to figure this one out
        }
    }

    //Checks if the pawn card move to a tile

    public void checkMove(bool state)
    {


        bool leftButtonPress = Input.GetMouseButton(0);
        Pawn pawn = gameObject.GetComponent<Pawn>();

        //mouse position on the screen and the scene world position.

        Vector2 mousePosition = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        if (leftButtonPress)
        {
            Debug.Log("Left button pressed");

            for (int i = 0; i < deckTiles.Count; i++)
            {
                deckTiles[i].transform.GetChild(1).gameObject.SetActive(false);

                //checks if the mouseWorld position is within borders of the tile collision component.
                if (deckTiles[i].GetComponent<Collider2D>().OverlapPoint(mouseWorldPosition))
                {
                    MovePawn(i, player, typeAdv);
                    

                    deckTiles[i].transform.GetChild(1).gameObject.SetActive(true);
                    Debug.Log("Is within the radius of the paddle. Object should move");
                    transformObjOne = deckTiles[i].transform.position;
                    transformObjTwo = deckTiles[i].transform.position;

                    if (Pawn.pawnExist == true)
                    {
                        if (deckTiles[i].transform.position == obj.GetComponent<Transform>().position)
                        {
                            Debug.Log("is equal to One");
                            Debug.Log("Player : " + obj.GetComponent<Transform>().position);
                            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.red;
                            PawnInstGridOne = true;
                        }
                        else
                        {
                            PawnInstGridOne = false;
                        }

                        if (deckTiles[i].transform.position == objTwo.GetComponent<Transform>().position)
                        {
                            Debug.Log("is equal to Two");
                            Debug.Log("Player : " + objTwo.GetComponent<Transform>().position);
                            deckTiles[i].transform.GetChild(1).gameObject.GetComponent<SpriteRenderer>().color = Color.yellow;
                            PawnInstGridTwo = true;
                        }
                        else
                        {
                            PawnInstGridTwo = false;
                        }
                    }
                    if (isMovableOne == true)
                    {
                        Debug.Log("isMovableToOne");
                    }
                    else if (isMovableTwo == true)
                    {
                        Debug.Log("isMovableToTwo");
                    }
                }
                else
                {
                    deckTiles[i].transform.GetChild(1).gameObject.SetActive(false);
                }
            }

            pawnOne = advCards.type;
            pawnTwo = advCards.typeTwo;

            for (int i = 0; i < deckTiles.Count; i++)
            {
                if (PawnInstGridOne == true)
                {
                    PawnInstGridTwo = false;
                    gridPlateIndicate(i, "One", pawnOne);
                }

                else if (PawnInstGridTwo == true)
                {
                    PawnInstGridOne = false;
                    gridPlateIndicate(i, "Two", pawnTwo);
                }
            }

        }
        else
        {
            Debug.Log("Left button not pressed.");
        }
    }

    public void MovePawn(int i, string player, string cardName)
    {

        if (player == "One")
        {
            objectPlate = obj.transform.position;
        }
        if (player == "Two")
        {
            objectPlate = objTwo.transform.position;
        }

         if (deckTiles[i].CurrentState != TileInfo.State.Sunk)
        {
            if (
                ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) && (deckTiles[i].transform.position.y == objectPlate.y) ||
                 (deckTiles[i].transform.position.x - objectPlate.x == 1.5f)) && (deckTiles[i].transform.position.y == objectPlate.y)
                ||
                 ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) && (deckTiles[i].transform.position.x == objectPlate.x) ||
                 (deckTiles[i].transform.position.y - objectPlate.y == 1.5f)) && (deckTiles[i].transform.position.x == objectPlate.x)

                )
            {


                pawnMove(i);

            }

            else if (cardName == "Explorer")
            {
                if (
                 ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) || (deckTiles[i].transform.position.x - objectPlate.x == 1.5f))
                &&
                 ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) || (deckTiles[i].transform.position.y - objectPlate.y == 1.5f))

                 )
                {
                    pawnMove(i);
                }
            }

            else if (cardName == "Pilot" &&
                (deckTiles[i].transform.position.y != objectPlate.y && deckTiles[i].transform.position.x != objectPlate.x))
            {

                pawnMove(i);

            }

            else if (cardName == "Navigator")
            {
                if (
                      ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) || (deckTiles[i].transform.position.x - objectPlate.x == 1.5f))
                      &&
                      ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) || (deckTiles[i].transform.position.y - objectPlate.y == 1.5f))

                      ||

                       ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) && (deckTiles[i].transform.position.y == objectPlate.y) ||
                       (deckTiles[i].transform.position.x - objectPlate.x == 1.5f)) && (deckTiles[i].transform.position.y == objectPlate.y)
                       ||
                       ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) && (deckTiles[i].transform.position.x == objectPlate.x) ||
                      (deckTiles[i].transform.position.y - objectPlate.y == 1.5f)) && (deckTiles[i].transform.position.x == objectPlate.x)

                )
                {
                    pawnMove(i);
                }
            }

            else
            {
                x = 0;
                Debug.Log("isNotMovable");
            }
        }

         else if (cardName != "Diver" && deckTiles[i].CurrentState == TileInfo.State.Sunk)
        {
            deckTiles[i].transform.GetChild(1).gameObject.SetActive(false);
        }
    }

    private void pawnMove(int i)
    {

        Debug.Log("isMovable");
        if (x == 1)
        {
            move = deckTiles[i].transform.position;

            if (player == "One")
            {
                Debug.Log("ShouldMoveOne");
                Debug.Log(move);
                GameObject.Find("PlayerOne").transform.position = move;
            }
            if (player == "Two")
            {
                Debug.Log(move);
                GameObject.Find("PlayerTwo").transform.position = move;
            }

            x = 0;

            gameManager.action = 10;
            gameManager.actionCounter++;
            Move.interactable = false;
        }
    }

    /*  The following is most, if not all,  the fucntions related to the shore up action
     *
     *  shoreUp: checks if the tiles are adjacent to the pawn and shores the chosen tile up
     *  
     *  
     *  Return: None
     */

    public void shoreEnable()
    {
        gameManager.action = 3;
    }

    public void shoreUp(string player, string cardName)
    {

        if (player == "One")
        {
            objectPlate = obj.transform.position;
        }

        if (player == "Two")
        {
            objectPlate = objTwo.transform.position;
        }

        for (int i = 0; deckTiles.Count > 0; i++)
        { 
                if (
                     ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) && (deckTiles[i].transform.position.y == objectPlate.y) ||
                     (deckTiles[i].transform.position.x - objectPlate.x == 1.5f)) && (deckTiles[i].transform.position.y == objectPlate.y)
                     ||
                     ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) && (deckTiles[i].transform.position.x == objectPlate.x) ||
                     (deckTiles[i].transform.position.y - objectPlate.y == 1.5f)) && (deckTiles[i].transform.position.x == objectPlate.x)
                  )
                {
                    if (deckTiles[i].CurrentState == TileInfo.State.Flooded)
                    {
                        deckTiles[i].CurrentState = TileInfo.State.Default;
                        gameManager.action = 10;
                    }
                    else if (deckTiles[i].CurrentState == TileInfo.State.Sunk || deckTiles[i].CurrentState == TileInfo.State.Default)
                    {
                        break;
                    }
                }
            

            if (cardName == "Explorer")
            {
                if (
                 ((deckTiles[i].transform.position.x - objectPlate.x == -1.5f) || (deckTiles[i].transform.position.x - objectPlate.x == 1.5f))
                &&
                 ((deckTiles[i].transform.position.y - objectPlate.y == -1.5f) || (deckTiles[i].transform.position.y - objectPlate.y == 1.5f))
                 )
                {
                    if (deckTiles[i].CurrentState == TileInfo.State.Flooded)
                    {
                        deckTiles[i].CurrentState = TileInfo.State.Default;
                        gameManager.action = 10;

                    }
                }
            }
        }
    }
}
