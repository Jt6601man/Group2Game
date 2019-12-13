using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject openChest;
    public GameObject gun;

    Transform chestPosition;


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
        Instantiate(openChest, chestPosition.position, chestPosition.rotation);
        Instantiate(gun, chestPosition.position, chestPosition.rotation);
        Destroy(gameObject);
    }
}
