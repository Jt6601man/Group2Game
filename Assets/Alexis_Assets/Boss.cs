using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public Transform playerTarget;

    Transform cannon;

    void Start()
    {
        cannon = GetComponent<Boss>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = (playerTarget.position - transform.position);
        delta.z = 0;
        cannon.transform.up = delta;
    }
}
