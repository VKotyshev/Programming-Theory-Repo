using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.IO;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;
    public bool gameOver;
    private float gameSpeed;
    private int point;
    public TextMeshProUGUI bestScoreText;
    public bool isBestExists;

    private string _currentName;
    private string _bestName;
    private int _bestScore;
    // Start is called before the first frame update
    private void Start()
    {
        gameOver = false;
        gameSpeed = 1f;
        LoadHighScore();
        bestScoreText.text = ShowHighScore();


        gameManager = this;
        
    }

    // Update is called once per frame
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


    [System.Serializable]
    class SaveData
    {
        public int point;
    }

    public void SaveHighScore(int point)
    {
        if (point <= bestScore) return;
        bestScore = point;

        SaveData data = new SaveData();
        data.point = point;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savedata.json", json);

        if (!isBestExists) isBestExists = true;
    }

    private void LoadHighScore()
    {
        isBestExists = File.Exists(Application.persistentDataPath + "/savedata.json");

        if (!isBestExists) return;

        string json = File.ReadAllText(Application.persistentDataPath + "/savedata.json");
        SaveData data = JsonUtility.FromJson<SaveData>(json);
        bestScore = data.point;
    }

    public string ShowHighScore()
    {
        if (!isBestExists) return "There is no record yet!";
        return $"{bestScore}";
    }
    public int bestScore { get { return _bestScore; } set { _bestScore = value; } }
}
