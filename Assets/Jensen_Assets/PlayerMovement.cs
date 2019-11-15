using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed = 5;

    float localScaleX;
    float localScaleY;

    private Animator anim;
    private Rigidbody2D myRigidbody;

    private bool playerMoving;
    private Vector2 lastMove;

    private GameObject swordObject;

    void Start()
    {
        
        localScaleX = transform.localScale.x;
        localScaleY = transform.localScale.y;
        anim = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
        swordObject = gameObject.transform.GetChild(0).gameObject;
    }

    void FixedUpdate()
    {
        playerMoving = false;

        if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
        }

        if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
        {
            playerMoving = true;
            lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
        }

        float horMovement = Input.GetAxis("Horizontal") * speed;
        float vertMovement = Input.GetAxis("Vertical") * speed;

        Rigidbody2D rb2 = GetComponent<Rigidbody2D>();
        rb2.velocity = new Vector3(horMovement, vertMovement, 0);

        if (Input.GetAxisRaw("Fire1") > 0.5f)
        {
            if (swordObject.activeSelf == true)
                return;

            //swordObject.SetActive(true);

            //LastMove to the right
            if (lastMove.y == 0f && lastMove.x > 0f)
            {
                swordObject.transform.localPosition = new Vector3(0.029f, -0.0154f, -3.105568f);
                swordObject.transform.rotation = new Quaternion(0, 0, 90, 0);
                swordObject.SetActive(true);
            }

            //LastMove to the left
            if (lastMove.y == 0f && lastMove.x < 0f)
            {
                swordObject.transform.localPosition = new Vector3(-0.0558f, -0.041f, -3.105568f);
                swordObject.transform.rotation = new Quaternion(0, 0, 270, 0);
                swordObject.SetActive(true);
            }

            //LastMove is down
            if (lastMove.y < 0f && lastMove.x == 0f)
            {
                swordObject.transform.localPosition = new Vector3(-0.009999473f, -0.05247724f, -3.105568f);
                swordObject.transform.rotation = Quaternion.identity;
                swordObject.SetActive(true);
            }

            //LastMove is up
            if (lastMove.y > 0f && lastMove.x == 0f)
            {
                swordObject.transform.localPosition = new Vector3(-0.003f, -0.02f, -3.105568f);
                swordObject.transform.rotation = new Quaternion(0,0,180,0);
                swordObject.SetActive(true);
            }

        }


        //anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        //anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("PlayerMoving", playerMoving);
        //anim.SetFloat("LastMoveX", lastMove.x);
        //anim.SetFloat("LastMoveY", lastMove.y);

    }
}
