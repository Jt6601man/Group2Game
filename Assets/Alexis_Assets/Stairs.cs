using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stairs : MonoBehaviour
{
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(gameObject.tag == "toWorld")
            SceneManager.LoadScene("OpenWorld");
        else if(gameObject.tag == "toBoss")
            SceneManager.LoadScene("BossDungeon");
        else if(gameObject.tag == "toDungeon")
            SceneManager.LoadScene("RegularDungeon");
    }
}
