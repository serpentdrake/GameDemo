using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb2d;
    public int speed;
    
    void Start()
    {
        
    }

    
    void Update()
    {
        if(Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(speed, 0);
            
        } 

        if(Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-speed, 0);
            transform.localScale = new Vector2(-1, 1);
        }
        if(Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 6f);
        }
    }
}
