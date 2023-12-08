using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class MainManager : MonoBehaviour
{
    public static MainManager Manager;
    public GameManager gameManager;
    public TextMeshProUGUI ScoreText;
    public GameObject GameOverText;
    private int m_Points;
    private int score;
    private float timer;
    private bool m_GameOver = false;


    // Start is called before the first frame update
    void Start()
    {
        GameOverText.SetActive(false);
        m_GameOver = false;
        Time.timeScale = 1f;

    }

    private void Update()
    {
        if (!m_GameOver)
        {
            timer += Time.deltaTime;
            int point = Convert.ToInt32(timer % 60);
            if (point >= 1)
            {
                AddPoint(1);
                point = 0;
            }
            int qty = GameObject.FindGameObjectsWithTag("Player").Length;
            if (qty == 0)
            {
                GameOver();
                Time.timeScale = 0f;
            }
            
        }
        if (m_GameOver)
        {
            if (Input.GetKeyDown(KeyCode.M))
            {
                SceneManager.LoadScene(0);
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                Restart();
            }
        }


    }
    public void AddPoint(int point)
    {
        m_Points += point;
        ScoreText.text = $"{m_Points}";
    }

    public void GameOver()
    {
        gameManager.SaveHighScore(m_Points);
        //highScoreText.text = GameManager.gameManager.ShowHighScore();
        Time.timeScale = 0f;
        m_GameOver = true;
        GameOverText.SetActive(true);

    }
    public void Restart()
    {
        GameOverText.SetActive(false);
        m_GameOver = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().path);
    }
}