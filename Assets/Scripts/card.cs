using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    [SerializeField] public CardManager tileManager;
    [SerializeField] public GameManager gameManager;
    public TreasureCardInfo cardInfo;
    public SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameObject.name = cardInfo.cardName;
    }

    public void Update()
    {
        spriteRenderer.sprite = cardInfo.Default;
    }
}
