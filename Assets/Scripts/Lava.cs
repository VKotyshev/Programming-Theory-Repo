using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;
using System;

public class Lava : MonoBehaviour
{
    private GameManager gameManager;
    private MainManager Manager;
    float scrollSpeed = 0.5f;
    Renderer rend;
    private Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        m_Material = GetComponent<Renderer>().material;
    }

    // Update is called once per frame
    void Update()
    {


        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, -offset));
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Brick"))
        {
            Destroy(other.gameObject);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            
        }
    }
}
