using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Pawn : MonoBehaviour
{
    [SerializeField] GameObject pawnPiece;
    [SerializeField] GameObject[,] pawnPos = new GameObject[6, 6];
    [SerializeField] GameObject button;
    public GameObject playerOne, playerTwo;

    public TileInfo Tile;
    public Vector2 mouseWorldPosition;
    public string player;
    GameObject pawn;
    public string typeOne, typeTwo;

    bool gameOver;
    Collider2D[] playerCollider;



    TileManager tileManager;

    private string currentPlayer = "One";
    public float positionX, positionY;  //Gets the position of the Adventure card tiles and assignes to the Pawn initial transforms

    float fetchOneX, fetchOneY, fetchTwoX, fetchTwoY;
    // Start is called before the first frame update


    private void Start()
    {

        typeOne = "Engineer";
        typeTwo = "Pilot";
    }

    //This should be renamed and called within the OnCLick function of the card.

    public void assignPaw()
    {
        playerOne = makePawn("PlayerOne", typeOne, fetchOneX, fetchOneY);
        playerTwo = makePawn("PlayerTwo", typeTwo, fetchTwoX, fetchTwoY);

        button.gameObject.SetActive(false);


    }

    //marks all the positions for the tiles
    public void assignCards(string Type)
    {
        Debug.Log(Type);
        Debug.Log(Type);

        switch (Type)
        {
            case "Engineer":
                pawn = GameObject.Find("BronzeGate");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;

            case "Pilot":
                pawn = GameObject.Find("FoolsLanding");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;

            case "Navigator":
                pawn = GameObject.Find("GoldGate");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;

            case "Messenger":
                pawn = GameObject.Find("SilverGate");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;

            case "Diver":
                pawn = GameObject.Find("IronGate");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;

            case "Explorer":
                pawn = GameObject.Find("CopperGate");
                positionX = pawn.transform.position.x;
                positionY = pawn.transform.position.y;
                break;
        }
    }

    public GameObject makePawn(string name, string type, float x, float y)
    {
        GameObject gameObject;
        gameObject = Instantiate(pawnPiece, new Vector3(0, 0, 0), Quaternion.identity);
        PawnManager pawn = gameObject.GetComponent<PawnManager>();
        pawn.name = name;
        pawn.setXBoard(x);
        pawn.setYBoard(y);
        pawn.activatePawn(type);
        return gameObject;
    }

    public void detectPlayer(string player)
    {
        if (player == "one")
        {
            assignCards(typeOne);
            fetchOneX = positionX;
            fetchOneY = positionY;
            Debug.Log(fetchOneX + "," + fetchOneY);
        }
        else if (player == "two")
        {
            assignCards(typeTwo);
            fetchTwoX = positionX;
            fetchTwoY = positionY;
            Debug.Log(fetchTwoX + "," + fetchTwoY);
        }
    }



    // Update is called once per frame
    void Update()
    {
        detectPlayer("one");
        detectPlayer("two");
    }
}