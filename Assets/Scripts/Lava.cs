using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{
    private GameManager gameManager;
    float scrollSpeed = 0.5f;
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
            gameManager.GameOver();
        }
    }
}
