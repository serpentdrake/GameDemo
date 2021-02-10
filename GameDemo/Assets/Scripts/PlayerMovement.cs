using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private LayerMask platformsLayerMask;
    public Rigidbody2D rb2d;
    public int speed;
    private Animator anim;
    private BoxCollider2D boxCollider2D;
    private bool canDjump;
    
    void Start()
    {
        anim = GetComponent<Animator>();
        boxCollider2D = transform.GetComponent<BoxCollider2D>();
    }

    
    void Update()
    {
      
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb2d.velocity = new Vector2(moveInput * speed, rb2d.velocity.y);
       
     
        //left right movement
        if( moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }


        //jumping
        if (IsGrounded())
        {
            canDjump = true;
        }

        if( Input.GetKey(KeyCode.W))
        {
            if (IsGrounded())
            {
                float jumpVel = 8f;
                rb2d.velocity = Vector2.up * jumpVel;

            }
            else
            {
                if (Input.GetKeyDown(KeyCode.W))
                {
                    if (canDjump)
                    {
                        float jumpVel = 8f;
                        rb2d.velocity = Vector2.up * jumpVel;
                        canDjump = false;
                    }
                }
            }
        }


        //animations

        if (IsGrounded())
        {
            anim.SetBool("isJumping", false);

            if(moveInput == 0)
            {
                anim.SetBool("isRunning", false);
            } 
            else
            {
                anim.SetBool("isRunning", true);
            }
        }
        else
        {
            anim.SetBool("isJumping", true);
        }
      
    }

    private bool IsGrounded()
    {
       RaycastHit2D raycastHit2D = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, .1f, platformsLayerMask);

        return raycastHit2D.collider != null;
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("movingPlatform"))
        {
            this.transform.parent = other.transform; 
        }
        //player death
        if (other.gameObject.CompareTag("death"))
        {
            Destroy(gameObject);
            LevelManager.instance.Respawn();
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
       if(other.gameObject.CompareTag("movingPlatform"))
        {
            this.transform.parent = null;
        }
    }
}
