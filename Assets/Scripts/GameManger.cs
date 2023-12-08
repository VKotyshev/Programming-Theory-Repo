using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gameOver;
    private float gameSpeed;
    private float score;
    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
        gameSpeed = 0.5f;
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void GameOver()
    {
        gameOver = true;
        Debug.Log("Game Over");
    }
    public float GameSpeed(float currentspped)
    {
        float currentspeed = gameSpeed;
        return currentspeed;
    }
}
