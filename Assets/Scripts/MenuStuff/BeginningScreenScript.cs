using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class BeginningScreenScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void PlayButton()
    {
        SceneManager.LoadScene("Episode1-Option1");
    }

    void OnPlay()
    {
        SceneManager.LoadScene("Episode1-Option1");
    }

    public void QuitButton()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    void OnQuit()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
