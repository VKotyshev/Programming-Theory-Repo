using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float currentspeed;
    private GameManager gameManager;
    public float speed;
    public GameObject prefabToSpawn; // префаб, который мы будем спавнить

    public float spawnInterval = 2f;  // интервал времени между спавном в секундах

    private float timer =2f;   // таймер для отслеживания времени
  

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {     // если прошло больше времени, чем интервал между спавном 
            SpawnObject();               // то мы спавнируем объект  
            
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-5f, 5f), 8f, -0.5f); // случайная позиция спавна в пределах определенного диапазона по X и текущей по Y (центр экрана)
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);  // создаем новый объект из префаба в заданной позиции без поворота относительно оси Z (Quaternion.identity)
        timer = 4f;                  // и сбрасываем таймер
    }
}

