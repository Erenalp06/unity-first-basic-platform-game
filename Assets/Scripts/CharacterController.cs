using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;

    private bool grounded, gameStarted, jumping;

    Rigidbody2D rigidbody2D;
    Animator animator;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
        
    }
    
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            if(gameStarted && grounded){                
                animator.SetTrigger("jump");
                grounded = false;
                animator.SetBool("grounded", grounded);
                jumping = true;              
            }else{
                animator.SetBool("GameStarted", true);
                gameStarted = true;
            }
            

        }

        //print("grounded : " + grounded);
        //print("position : " + transform.position);
    }
    
    void FixedUpdate()
    {
        if(gameStarted){
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
        }

        if(jumping){
            //rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            jumping = false;
        }

        
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground")){
            grounded = true;
            animator.SetBool("grounded", grounded);
        }
    }
    

    
}
