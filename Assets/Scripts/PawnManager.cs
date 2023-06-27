using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PawnManager : MonoBehaviour
{
    [SerializeField] GameObject pawnManager;
    [SerializeField] GameObject cardBorder;
    [SerializeField] Sprite Engineer, Navigator, Pilot, Messenger, Explorer, Diver;
    private string player;
    private float xBoard = -1;
    private float yBoard = -1;



    public void pieceTransform()
    {
        float x = xBoard;
        float y = yBoard;
        this.transform.position = new Vector3(x, y, 0);
    }

    public float GetXBoard()
    {
        return xBoard;
    }

    public float GetYBoard()
    {
        return yBoard;
    }

    public void setXBoard(float x)
    {
        xBoard = x;
    }

    public void setYBoard(float y)
    {
        yBoard = y;
    }

    public void activatePawn(string name)
    {

        pieceTransform();

        switch (name)
        {
            case "Engineer": 
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Engineer; 
                break;
            case "Pilot": 
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Pilot;
                break;
            case "Navigator":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Navigator;
                break;
            case "Messenger":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Messenger;
                break;
            case "Diver":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Diver;
                break;
            case "Explorer":
                this.gameObject.GetComponent<SpriteRenderer>().sprite = Explorer;
                break;
        }
    }

    
}