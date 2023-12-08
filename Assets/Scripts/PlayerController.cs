using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float playerSpeed = 2.0f;
    public float JumpForce = 1.0f;

    private CharacterController m_Controller;
    private Animator m_Animator;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    private float gravityValue = -9.81f;

    private void Start()
    {
        m_Controller = gameObject.GetComponent<CharacterController>();
        m_Animator = gameObject.GetComponentInChildren<Animator>();
    }

    void Update()
    {
        groundedPlayer = m_Controller.isGrounded;

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = -5f;
        }

        Vector3 input = new Vector3(Input.GetAxis("Horizontal"), 0,0 );

        //trasnform input into camera space
        var forward = gameObject.transform.forward;
        forward.y = 0;
        forward.Normalize();
        var right = Vector3.Cross(Vector3.up, forward);
        
        Vector3 move = right * -input.x;
        move.y = 0;

        m_Controller.Move(move * Time.deltaTime * playerSpeed);

        m_Animator.SetFloat("MovementX", input.z * Time.deltaTime);
        m_Animator.SetFloat("MovementZ", input.x * Time.deltaTime);

        if (input != Vector3.zero)
        {
            gameObject.transform.forward = forward;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(JumpForce * -3.0f * gravityValue +5.0f);
            m_Animator.SetTrigger("Jump");
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        m_Controller.Move(playerVelocity * Time.deltaTime);
        
    }
    //public void OnCollisionEnter(Collision collision)
    //{
        //if (collision.gameObject.CompareTag("Brick"))
       // {
        //    transform.SetParent(collision.gameObject.transform);
       // }
    //}
       
}
