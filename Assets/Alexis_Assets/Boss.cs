using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject playerTarget;

    Transform cannon;
    public List<Vector2> waypoints = new List<Vector2>();

    void Start()
    {
        cannon = GetComponent<Boss>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = (playerTarget.transform.position - transform.position);
        delta.z = 0;
        cannon.transform.up = delta;
    }

    private void OnDrawGizmosSelected()
    {
        foreach (Vector2 v in waypoints)
            Gizmos.DrawSphere((Vector3)v, .25f);
    }
}
