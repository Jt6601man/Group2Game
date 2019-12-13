using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WinLoseButtons : MonoBehaviour
{
    public GameObject overlay;
    private bool buttonPressed = false;

    public void Start()
    {
        overlay = GameObject.FindGameObjectWithTag("Overlay");
        overlay.SetActive(false);
    }

    public void Update()
    {
        if (buttonPressed == true)
        {
            overlay.GetComponent<Image>().color = Color.Lerp(Color.clear, Color.black, Mathf.PingPong(Time.time, 3f));
        }
    }

    public void backToMenu()
    {
        overlay.SetActive(true);
        buttonPressed = true;
        Invoke("sceneLoad", 3);
    }

    public void sceneLoad()
    {
        SceneManager.LoadScene(0);
    }
}
