using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class waterMeter : MonoBehaviour
{
    [SerializeField]
    GameObject WaterLevel;
    public CardManager waterLevelCounter;
    [SerializeField]
    GameObject[] LevelPoints;
    Vector2 levelPos;
    public int levelIndex = 0;
    public float speed;

    void upLevel()
    {
        for (int x = 0; x < LevelPoints.Length; x++)
        {
            if (levelIndex == x)
            {
                levelPos = Vector2.MoveTowards(WaterLevel.transform.position, LevelPoints[x].transform.position, Time.deltaTime * speed);
                WaterLevel.transform.position = levelPos;
            }
        }
    }

    private void Update()
    {
        upLevel();
        levelIndex = waterLevelCounter.waterLevelCounter;
    }
}
