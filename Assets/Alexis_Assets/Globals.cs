using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globals : MonoBehaviour
{
    public static WaypointGizmos waypointGizmos = null;

    PlayerMovement playerStuff;

    void Awake()
    {
        waypointGizmos = FindObjectOfType<WaypointGizmos>();
        playerStuff = FindObjectOfType<PlayerMovement>();
    }

    void Start()
    {
        if (PlayerPrefs.HasKey("gotHealth"))
        {
            playerStuff.ChangeHealth(PlayerPrefs.GetInt("gotHealth"));

            Debug.Log(playerStuff.GetHealth());

            for (int i = 2; i > playerStuff.GetHealth() - 1; i--)
                playerStuff.ChangeHeartActive(i);
        }

        if (PlayerPrefs.HasKey("gotGun"))
        {
            int gunNum = PlayerPrefs.GetInt("gotGun");

            if (gunNum == 0)
                playerStuff.GotGun(false);
            else
                playerStuff.GotGun(true);
        }
    }
}
