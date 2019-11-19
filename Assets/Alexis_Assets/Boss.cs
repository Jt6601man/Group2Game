using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public GameObject playerTarget;
    public float speed = 2;
    public float gunDamage = 3;
    public float swordDamage = 1;
    public float maxHealth = 30;
    public GameObject sword;

    float currentHealth;
    Transform cannon;
    Vector2 currentGizmo;
    int currentIndex = 0;
    //GameObject gun;
    Slider healthBar;


    void Start()
    {
        currentHealth = maxHealth;
        cannon = GetComponent<Boss>().transform;
        //gun = ;
        healthBar = cannon.GetChild(0).GetChild(0).GetComponent<Slider>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == sword)
        {
            Debug.Log("Sword Hit");
            //currentHealth -= swordDamage;
            //StartCoroutine(Hit(currentHealth));
        }
       // else if (collision.gameObject == gun)
       //     Debug.Log("Gun Hit");
    }

    //IEnumerator Hit(float health)
    //{
    //    healthBar.value = health / maxHealth;
    //
    //    cannon.gameObject.GetComponent<SpriteRenderer>().color = Color.red;
    //
    //    yield return new WaitForSeconds(3f);
    //
    //    cannon.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    //}
}
