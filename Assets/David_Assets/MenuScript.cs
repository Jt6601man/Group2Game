using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour {
    public string sceneToLoad;
    public GameObject aboutCanvas;

    void Start()
    {
        aboutCanvas.SetActive(false);
    }
    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    }
    public void Play()
    {
        SceneManager.LoadScene(sceneToLoad);

    }

    public void About()
    {
        aboutCanvas.SetActive(true);
    }

    public void Back()
    {
        aboutCanvas.SetActive(false);
    }


}
