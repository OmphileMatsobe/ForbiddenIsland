using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "cards", menuName = "ScriptableObjects/cards", order = 1)]
public class scriptableObjects : ScriptableObject
{
    public int id;
    public string cardName, description;
    public string action;
    public string cardImageName;
}
