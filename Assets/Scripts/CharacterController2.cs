using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController2 : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    private Rigidbody2D rigidbody2D;
    private bool isGrounded = false;
    private float groundCheckRadius = 0.2f;
    public Transform groundCheck;
    public LayerMask groundLayer;

    private SpriteRenderer spriteRenderer;

    private Animator animator;

   

    
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        
    }

    
    void Update()
    {      


        if(Input.GetAxisRaw("Horizontal") < 0){
            spriteRenderer.flipX = true;
        }else{
            spriteRenderer.flipX = false;
        }
    }

    
    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        float moveInput = Input.GetAxisRaw("Horizontal");
        animator.SetFloat("speed", Mathf.Abs(moveInput));
        rigidbody2D.velocity = new Vector2(moveInput * moveSpeed, rigidbody2D.velocity.y);
        
        if(isGrounded && Input.GetKey(KeyCode.Space)){     
            print("Jump");
            animator.SetTrigger("jump");       
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
        }

        animator.SetBool("isGrounded", isGrounded);
        
        //print("Ground : " + isGrounded);
    }

    
}
