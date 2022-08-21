using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public float speed;
    public float jumpForce;
    private Rigidbody2D rigidb;
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
            //transforming RigidBody2D through method AddForce that goes add one force, through variable jumpforce
            //finally, ForceMode2D is responsabilized for giving impulse the Player 
            rigidb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }
}
