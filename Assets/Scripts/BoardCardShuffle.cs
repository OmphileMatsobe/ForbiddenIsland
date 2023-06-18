using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BoardCardShuffle : MonoBehaviour
{
    [SerializeField]
    GameObject[] boardCard, nodePoints;
    [SerializeField]
    GameObject point;
    Vector2 nodePos;
    public float speed;
    public List<int> indexRandom = new List<int>();
    
    // Start is called before the first frame update
    void Start()
    {
        umiqueRandom();
        for (int i = 0; i < boardCard.Length; i++)
        {
            boardCard[i].transform.position = point.transform.position;
        }
    }

    void umiqueRandom()
    {
        for (int i = 0; i < boardCard.Length; i++)
        {
            indexRandom.Add(i);
        }
        indexRandom = indexRandom.OrderBy(random => System.Guid.NewGuid()).ToList();
    }
    
    void moveTowards()
    {
        for (int i = 0; i < boardCard.Length; i++)
        {
            nodePos = Vector2.MoveTowards(boardCard[i].transform.position, nodePoints[indexRandom[i]].transform.position, Time.deltaTime * speed);
            boardCard[i].transform.position = nodePos;
        }
    }

    // Update is called once per frame
    void Update()
    {
        moveTowards();
    }
}