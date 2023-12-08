using System;
using UnityEngine;

public class SimpleMovement : MonoBehaviour
{
    private float currentspeed;
    private GameManager gameManager;
    public float speed;
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }
    void fixedUpdate()
    {
        transform.Translate(Vector3.down * gameManager.GameSpeed(currentspeed));
    }
}