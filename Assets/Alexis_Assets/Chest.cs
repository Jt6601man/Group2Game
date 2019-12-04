using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public GameObject openChest;

    Transform chestPosition;

    static bool enemyDead;

    void Start()
    {
        chestPosition = gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDead)
        {
            Instantiate(openChest, chestPosition.position, chestPosition.rotation);
            Destroy(gameObject);
        }
    }
}
