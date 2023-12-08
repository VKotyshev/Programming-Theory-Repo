using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class background : MonoBehaviour
{
    private GameManager gameManager;
    float scrollSpeed = 0.03f;
    Renderer rend;
    public Material m_Material;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        m_Material = GetComponent<Renderer>().material;
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {


        float offset = Time.time * scrollSpeed;
        rend.material.SetTextureOffset("_MainTex", new Vector2(0, offset));
    }

}