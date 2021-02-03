using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public int speed;
    private Animator anim;
    
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        bool isGrounded = true;
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
        bool isJumping = false;
        bool doublejump = false;
     
        if( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if(isGrounded == true && Input.GetKey(KeyCode.W))
        {
            isJumping = true;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 6f);
            anim.SetBool("isJumping", true);
        }
        else
        {
            anim.SetBool("isJumping", false);
        }
        if(isJumping == true && Input.GetKey(KeyCode.W))
        {
            doublejump = true;
            anim.SetBool("isJumping", true);
        }
        if( doublejump == true && Input.GetKey(KeyCode.W))
        {

        }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }
      
    }
}
