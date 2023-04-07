using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float jumpForce = 5f;
    [SerializeField] private float fallMultiplier = 2.5f;
    [SerializeField] private float lowJumpMultiplier = 2f;

    public static CharacterController Instance;

    private bool grounded, gameStarted, jumping;

    public bool hurted;

    Rigidbody2D rigidbody2D;
    Animator animator;
    
    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        grounded = true;
        if(Instance  == null){
            Instance = this;
        }
        
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

        animator.SetBool("hurt", hurted);
        //print("hurt" + hurted);

        //print("grounded : " + grounded);
        //print("position : " + transform.position);
    }
    
    void FixedUpdate()
    {
        if(gameStarted && !hurted){
            rigidbody2D.velocity = new Vector2(moveSpeed, rigidbody2D.velocity.y);
        }

        /*if(jumping && !hurted){
            //rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            jumping = false;
        }*/

        if(jumping && !hurted){
            //rigidbody2D.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            rigidbody2D.velocity = Vector2.up * jumpForce;

            if(rigidbody2D.velocity.y < 0){
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }else if (rigidbody2D.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rigidbody2D.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
            jumping = false;

            //rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x, jumpForce);
            
        }

        
    }

    
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("ground")){
            grounded = true;
            animator.SetBool("grounded", grounded);
        }

        if(other.gameObject.CompareTag("obstacle")){
            hurted = true;
            
        }

        
    }
    

    
}
