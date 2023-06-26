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

            cardManager.RemoveFromHand(this, gameManager.playerTurn); // Pass the clickedCard itself
            gameManager.UpdateHand(this , gameManager.playerTurn);
            gameObject.SetActive(false);
            Debug.Log("Pressed");
        
    }


}

