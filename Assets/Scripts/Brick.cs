using System;
using UnityEngine;

public class Brick : MonoBehaviour
{
    private float currentspeed;
    private GameManager gameManager;
    public float speed;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void Update()
    {
        transform.Translate(Vector3.down * gameManager.GameSpeed(currentspeed) * Time.deltaTime);
    }
}