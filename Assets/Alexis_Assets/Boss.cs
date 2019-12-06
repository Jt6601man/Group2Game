using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Boss : MonoBehaviour
{

    public GameObject playerTarget;
    public float speed = 2;

    //Private so that the damage values match the values needed to change the health slider
    float gunDamage = 0.1f;
    float swordDamage = 0.05f;
    float maxHealth = 1f;

    //private because it can be found using the player object
    GameObject sword;

    float currentHealth;
    Transform cannon;
    Vector2 currentGizmo;
    int currentIndex = 0;
    //GameObject gun;
    Slider healthBar;

    public GameObject projectile;


    void Start()
    {
        currentHealth = maxHealth;
        cannon = GetComponent<Boss>().transform;
        //gun = ;

        //Find healthbar through ObjectOfType slider
        healthBar = FindObjectOfType<Slider>();
        //Find sword by finding the players child gameobject
        sword = playerTarget.transform.GetChild(0).gameObject;

        Invoke("Shoot", 2);
    }

    void Update()
    {
        //Rotates Cannon
        Vector3 turn = (playerTarget.transform.position - transform.position);
        turn.z = 0;
        cannon.transform.up = turn;

        //Moves Cannon
        Vector2 delta = currentGizmo - (Vector2)transform.position;

        if (delta.magnitude <= .1f)
            StartCoroutine(WaitToMove());

        UpdateCurrentGizmo();

        delta = delta.normalized;
        transform.position += (Vector3)delta * speed * Time.deltaTime;

        if (healthBar.value == 0)
        {
            SceneManager.LoadScene(4);
            Destroy(gameObject);
        }
    }

    void UpdateCurrentGizmo()
    {
        currentGizmo = Globals.waypointGizmos.waypoints[currentIndex] + Random.insideUnitCircle;
    }

    IEnumerator WaitToMove()
    {
        if (currentIndex >= 4)
            currentIndex = 0;
        else
            currentIndex++;

        yield return new WaitForSeconds(15.00f);
    }

    //OnCollision code
    private void OnCollisionEnter2D(Collision2D collision)
    {    
        //Since the sword tag isn't used, and if the cannon collides with the sword it thinks its the player
        //The work around was checking if the collision tag was player and also if the sword is active
        //This makes it so that only when the sword is active the cannon will take damage from
        //collision with the player object
        if (sword.activeSelf == true && collision.gameObject.tag == "Player")
        {
            currentHealth -= swordDamage; //Subtract the sword damage amount from the curent health
            healthBar.value = currentHealth; //Set the healthBar value to the current health value
        }
       else if (collision.gameObject.tag == "Bullet")
        {
            currentHealth -= gunDamage; //Subtract the bullet damage amount from the curent health
            healthBar.value = currentHealth; //Set the healthBar value to the current health value
        }
    }

    void Shoot()
    {
        Instantiate(projectile, gameObject.transform.position, gameObject.transform.rotation);
        Invoke("Shoot", 2);
    }

}
