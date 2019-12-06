using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject openChest;
    public GameObject gun;

    Transform chestPosition;

    static bool enemyDead;
    //bool enemyDead = true;

    void Start()
    {
        chestPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (enemyDead)
        {
            Instantiate(openChest, chestPosition.position, chestPosition.rotation);
            Instantiate(gun, chestPosition.position, chestPosition.rotation);
            Destroy(gameObject);
        }
    }
}
