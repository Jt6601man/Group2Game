using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{

    Rigidbody2D rb;
    public float speed = 3;
    private float acceleration;

    // Start is called before the first frame update
    void Start()
    {
        acceleration += Time.deltaTime * speed;
        rb = gameObject.GetComponent<Rigidbody2D>();
        Invoke("Die", 2);
    }

    // Update is called once per frame
    void Update()
    {
        acceleration += Time.deltaTime * speed;
        rb.velocity = transform.up * acceleration;
    }

    void Die()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Boss")
        {
            Destroy(gameObject);
        }
    }
}
