using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    bool gotGun;
    int currentHealth;
    int gotGunAsInt;

    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerMovement playerStuff = FindObjectOfType<PlayerMovement>();

        currentHealth = playerStuff.GetHealth();
        gotGun = PlayerMovement.gotGun;

        if (gotGun)
            gotGunAsInt = 1;
        else
            gotGunAsInt = 0;

        PlayerPrefs.SetInt("gotHealth", currentHealth);
        PlayerPrefs.SetInt("gotGun", gotGunAsInt);
        PlayerPrefs.Save();

        if (collision.gameObject.tag == "Player")
        {
            if (gameObject.tag == "toWorld")
                SceneManager.LoadScene("OpenWorld");
            else if (gameObject.tag == "toBoss")
                SceneManager.LoadScene("BossDungeon");
            else if (gameObject.tag == "toDungeon")
                SceneManager.LoadScene("RegularDungeon");
        }
    }
}
