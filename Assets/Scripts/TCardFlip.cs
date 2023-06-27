using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TCardFlip : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;

    public void animateTreasureFlip()
    {
        animator.SetTrigger("TreasureFlip");
        gameObject.transform.position = new Vector3(-2.46f, 4.96f, 1f);
        gameObject.transform.rotation = Quaternion.identity;

    }
}