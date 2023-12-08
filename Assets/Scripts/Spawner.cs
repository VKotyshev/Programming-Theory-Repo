using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    private float currentspeed;
    private GameManager gameManager;
    public float speed;
    public GameObject prefabToSpawn; 

    public float spawnInterval = 2f; 

    private float timer =2f;   
  

    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

    }

 
    void FixedUpdate()
    {
        timer -= Time.deltaTime;
        if (timer <=0)
        {    
            SpawnObject();          
            
        }
    }

    void SpawnObject()
    {
        Vector3 spawnPosition = new Vector3(Random.Range(-6f, 6f), 20f, -0.5f);
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
        timer = 2f;
    }
}

