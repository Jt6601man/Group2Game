using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //variable for walking speed
    public float speed = 5;

    //Private animator and rigidbody2d
    private Animator anim;
    private Rigidbody2D myRigidbody;

    //bool for if player is moving and Vector2 to hold the players last move values (x,y)
    private bool playerMoving;
    private Vector2 lastMove;

    //gameObject for sword and sword sprite
    private GameObject swordObject;
    private SpriteRenderer swordSprite;

    void Start()
    {
        //get the animator
        anim = GetComponent<Animator>();
        //Get the rigidbody
        myRigidbody = GetComponent<Rigidbody2D>();

        //get the players first child (the Sword)
        swordObject = gameObject.transform.GetChild(0).gameObject;
        //get the spriteRenderer for the child of the sword object (this is where the sprite for the sword is
        //the swinging of the object and the sprite itself had to be seperated)
        swordSprite = swordObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        //Set player moving bool to false
        playerMoving = false;

        //If axis for horizontal
        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            //Set player moving to true
            playerMoving = true;
            //set last move to x = (the input axis value), y = 0)
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        //If axis for vertical
        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            //Set player moving to true
            playerMoving = true;
            //set last move to x = 0, y = (the input axis value))
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        //Floats for the speed of the movement based on the axis values
        float horMovement = Input.GetAxis("Horizontal") * speed;
        float vertMovement = Input.GetAxis("Vertical") * speed;

        //set the rigidBody velocity to those values for x and y, and z to 0
        myRigidbody.velocity = new Vector3(horMovement, vertMovement, 0);


        //Code for awake and swing sword
        //If the input axis for Fire1 is pressed (Set to spaceBar)
        if (Input.GetAxisRaw("Fire1") > 0.5f)
        {
            //If the sword is already active return
            if (swordObject.activeSelf == true)
                return;

            //Set the sorting order on the sprite to 11
            //This is used to put the sword in front of the player
            //(when the player is moving up, it will be behind their sprite)
            swordSprite.sortingOrder = 11;

            //LastMove to the right
            if (lastMove.y == 0f && lastMove.x > 0f)
            {
                //set the sword position and rotation to where it needs to be for this direction
                //and set the sword to active
                swordObject.transform.localPosition = new Vector3(0.035f, -0.0347f, -3.105568f);
                swordObject.transform.rotation = Quaternion.Euler(0, 0, 90);
                swordObject.SetActive(true);
            }

            //LastMove to the left
            if (lastMove.y == 0f && lastMove.x < 0f)
            {
                //set the sword position and rotation to where it needs to be for this direction
                //and set the sword to active
                swordObject.transform.localPosition = new Vector3(-0.0558f, -0.041f, -3.105568f);
                swordObject.transform.rotation = Quaternion.Euler(0, 0, 270);
                swordObject.SetActive(true);
            }

            //LastMove is down
            if (lastMove.y < 0f && lastMove.x == 0f)
            {
                //set the sword position and rotation to where it needs to be for this direction
                //and set the sword to active
                swordObject.transform.localPosition = new Vector3(-0.009999473f, -0.05247724f, -3.105568f);
                swordObject.transform.rotation = Quaternion.identity;
                swordObject.SetActive(true);
            }

            //LastMove is up
            if (lastMove.y > 0f && lastMove.x == 0f)
            {
                //Sorting order 9 puts the sword behind the player sprite, as if they're swinging it from the front
                swordSprite.sortingOrder = 9;

                //set the sword position and rotation to where it needs to be for this direction
                //and set the sword to active
                swordObject.transform.localPosition = new Vector3(-0.003f, 0.0023f, -3.105568f);
                swordObject.transform.rotation = Quaternion.Euler(0, 0, 180);
                swordObject.SetActive(true);
            }

        }


        //Basis for animator code, currently unused

        //anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        //anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        //anim.SetFloat("LastMoveX", lastMove.x);
        //anim.SetFloat("LastMoveY", lastMove.y);

    }
}
