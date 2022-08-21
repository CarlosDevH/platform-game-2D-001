using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rigidb;
    public bool isJumping;
    public bool doubleJump;
    // Start is called before the first frame update
    void Start()
    {
        //When the start game it will be localized the component RigidBody 2D from Player
        rigidb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
    void Move()
    {
        //collecting value from keyboard
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        //transforming position from player through the speed multiplied per DeltaTime method 
        transform.position += movement * Time.deltaTime * speed;
    }
    void Jump()
    {
        //collecting button pressioned from jump (space)
        if(Input.GetButtonDown("Jump"))
        {
            //Case isJumping false, one force is add in the player for the jump
            //and doubleJump, it will be true, allowing the player to jump again 
            if(!isJumping)
            {
            //transforming RigidBody2D through method AddForce that goes add one force, through variable jumpforce
            //finally, ForceMode2D is responsabilized for giving impulse the Player 
            rigidb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
            doubleJump = true;
            }
            else
            {
                //After if(!isJumping) be executed, the else with doubleJump it will be executed
                //per doubleJump be true previously, the conditicon it will be executed
                //therefore the player to jump again
                //finally, double jump will stay with false, for the the player not jumping infinitely
                if(doubleJump)
                {
                     rigidb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse); 
                     doubleJump = false;
                }
            }
         
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            //if the gameObject cath up layer 8, variable isJumping it will be false
            isJumping = false;
        }
    }
    void OnCollisionExit2D(Collision2D collision)
    {
          if(collision.gameObject.layer == 8)
        {
            //if the player drop down, isJumping it will be false
            isJumping = true;
        }
    }
}

