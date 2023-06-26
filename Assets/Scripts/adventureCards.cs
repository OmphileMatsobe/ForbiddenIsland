using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


[System.Serializable]
public class adventureCards : MonoBehaviour
{
    [SerializeField] GameObject nodePoint, nodePointTwo;
    public GameObject[] boardCard;
    [SerializeField] Vector2 nodePos, nodePos1, nodePos2;
    public Pawn pawns;
    public float speed = 10;
    public List<int> indexRandom = new List<int>();

    public string type, typeTwo;


    // Start is called before the first frame update
    void Start()
    {
        uniqueRandom();
        for (int i = 0; i < boardCard.Length; i++)
        {
            boardCard[i].SetActive(false);
        }

        controlAll();

        Invoke("activate", 3f);
        

    }

    void controlAll()
    {
            boardCard[indexRandom[0]].transform.position = nodePoint.transform.position;
            boardCard[indexRandom[1]].transform.position = nodePointTwo.transform.position;


        type = boardCard[indexRandom[0]].GetComponent<characterInfo>().Name;
        typeTwo = boardCard[indexRandom[1]].GetComponent<characterInfo>().Name;

        Debug.Log(boardCard[indexRandom[1]].GetComponent<characterInfo>().Name);

        
    }

    void activate()
    {
        for (int i = 0; i < 2; i++)
        {
            boardCard[indexRandom[i]].SetActive(true);
        }
    }

    void uniqueRandom()
    {
        for (int i = 0; i < boardCard.Length; i++)
        {
            indexRandom.Add(i);
            
        }

        indexRandom = indexRandom.OrderBy(random => System.Guid.NewGuid()).ToList();
        
    }



    public void Update()
    {
        type = boardCard[indexRandom[0]].GetComponent<characterInfo>().Name;
        typeTwo = boardCard[indexRandom[1]].GetComponent<characterInfo>().Name;

        Debug.Log(boardCard[indexRandom[0]].GetComponent<characterInfo>().Name);
        Debug.Log(boardCard[indexRandom[1]].GetComponent<characterInfo>().Name);

    }
}