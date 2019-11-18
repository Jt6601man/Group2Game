using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    public GameObject playerTarget;
    public float speed = 2;

    Transform cannon;
    Vector2 currentGizmo;
    int currentIndex = 0;

    void Start()
    {
        cannon = GetComponent<Boss>().transform;
        UpdateCurrentGizmo();
    }

    void Update()
    {
        Vector3 turn = (playerTarget.transform.position - transform.position);
        turn.z = 0;
        cannon.transform.up = turn;

        Vector2 delta = currentGizmo - (Vector2)transform.position;

        if (delta.magnitude <= .1f)
            Debug.Log("Put Coroutine here");

        delta = delta.normalized;
        transform.position += (Vector3)delta * speed * Time.deltaTime;
    }

    void UpdateCurrentGizmo()
    {
        currentGizmo = Globals.waypointGizmos.waypoints[currentIndex] + Random.insideUnitCircle;
    }

    IEnumerable WaitToMove()
    {
        if (currentIndex > 5)
            currentIndex = 0;
        else
            currentIndex++;

        UpdateCurrentGizmo();

        yield return new WaitForSeconds(1.25f);
    }
}
