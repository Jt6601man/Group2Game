using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointGizmos : MonoBehaviour
{

    public List<Vector2> waypoints = new List<Vector2>();

    private void OnDrawGizmosSelected()
    {
        foreach (Vector2 v in waypoints)
            Gizmos.DrawSphere((Vector3)v, .25f);
    }
}
