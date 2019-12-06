using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestScript : MonoBehaviour
{
    BoxCollider2D[] colliders;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Debug.Log("wassup");
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            //Instantiate
            colliders = gameObject.GetComponents<BoxCollider2D>();
            foreach (BoxCollider2D collider in colliders)
            {
                if (collider.isTrigger)
                {
                    Destroy(collider);
                }
            }
        }
    }
}
