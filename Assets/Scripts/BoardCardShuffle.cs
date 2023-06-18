using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardCardShuffle : MonoBehaviour
{
    [SerializeField]
    GameObject[] boardCard, nodePoints;
    [SerializeField]
    GameObject point;
    Vector2 nodePos;
    public float speed;
    public int[] random;
    bool unique = true;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < boardCard.Length; i++)
        {
            boardCard[i].transform.position = point.transform.position;
            random[i] = Random.Range(0, 23);
            Debug.Log(random[i]);
            
        }
    }

    void checkIfUnique()
    {
        for (int i = 0; i < random.Length; i++)
        {
            for (int x = 0; x < random.Length; i++)
            {
                if (random[i] == random[x])
                {
                    Debug.Log("Not Unique");
                    Debug.Log(random[x]);
                    unique = false;
                }
                else
                {
                    Debug.Log("Not Unique");
                    unique = true;
                }
            }
        }
    }
    void moveTowards()
    {
        for (int i = 0; i < boardCard.Length; i++)
        {

            nodePos = Vector2.MoveTowards(boardCard[i].transform.position, nodePoints[random[i]].transform.position, Time.deltaTime * speed);
            boardCard[i].transform.position = nodePos;
        }
    }

    // Update is called once per frame
    void Update()
    {

        moveTowards();
    }
}