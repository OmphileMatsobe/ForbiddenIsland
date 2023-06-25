using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFlip : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Animator animator;

    public void animateFlip()
    {
        animator.SetTrigger("DrawCard");
        gameObject.transform.position = new Vector3(-2.46f, 7.37f, 1f);
        gameObject.transform.rotation = Quaternion.identity;
    }
}
