﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static WaypointGizmos waypointGizmos = null;

    void Awake()
    {
        waypointGizmos = FindObjectOfType<WaypointGizmos>();
    }
}
