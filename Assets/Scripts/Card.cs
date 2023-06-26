using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public CardManager cardManager;
    [SerializeField] public GameManager gameManager;
    public TreasureCardInfo cardInfo;
    public SpriteRenderer spriteRenderer;

    public bool clickable = false;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.name = cardInfo.cardName;
    }

    public void Update()
    {
        spriteRenderer.sprite = cardInfo.Default;
       
    }

    private void OnMouseDown()
    {
        if (gameManager.handLimit == true)
        {
            cardManager.RemoveFromHand(this, 1, true); // Pass the clickedCard itself
            cardManager.RemoveFromHand(this, 2, true); // Pass the clickedCard itself
            gameManager.UpdateHand(this, 2);
            gameManager.UpdateHand(this, 1);
            gameObject.SetActive(false);
            Debug.Log("handlimit");
        }
        /*else if(gameManager.ableToPassTreasure == true && gameManager.handLimit == false)
        {
            
            cardManager.PassTreasure(this, gameManager.playerTurn, true);
            gameManager.UpdateHand(this, 2);
            gameManager.UpdateHand(this, 1);
        }
        else
        {

        }*/
        
    }


}

