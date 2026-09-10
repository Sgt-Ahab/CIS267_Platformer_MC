//==================================================
//Author: David Sargent
//Date: 2026-09-10
//Desc: Handles all player interaction with the world
//Attach: Player
//==================================================

using UnityEngine;
//This is required for loading a sceen
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    //Access the player rigid body
    private Rigidbody2D player_rb;
    //Make a variable to control the speed of the player
    //Setter/Getters not effective in unity
    [SerializeField]
    private float movementSpeed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Set RigidBody variable
        //We can grab this because we have access to the RigidBody2D, by being attached to the player object
        player_rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerLateral();   
    }
    
    private void movePlayerLateral()
    {
        //if A/D/<-/-> are pressed move accordingly
        //"Horizontal" is defined in the input section of the project settings
        //The line below will return:
        //0 - No Button Pressed
        //1 - Right Arrow / D pressed
        //2 - Left Arrow / A pressed
        float inputHorizontal = Input.GetAxisRaw("Horizontal");
        flipPlayerSprite(inputHorizontal);
        player_rb.linearVelocity = new Vector2(inputHorizontal * movementSpeed, player_rb.linearVelocityY);
    }
    
    private void flipPlayerSprite(float input)
    {
        //This function takes input to flip the player sprite accordingly
        if(input > 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);

        }
        else if(input < 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }    
    }

    //This is a prebuilt function that will detect collisions
    //in order to detect collisions both of the following must be true:
    //1. both objects need to have a collider
    //2. one of the objects need a rigidbody
    // 3 different collision: onenter, onexit, onstay

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //CompareTag is a general statement, to avoid clutter
        if(collision.gameObject.CompareTag("OB"))
        {
            Debug.Log("Restart Level");
            SceneManager.LoadScene("SampleScene");
        }
    }
}
