using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sourced this code from https://gamedevbeginner.com/the-right-way-to-pause-the-game-in-unity/
public class PauseControl : MonoBehaviour
{
    public static bool gameIsPaused;

    public Animator animator;

    public Animator animator2;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }

    }

    void OnWait()
    {
        /*if (Input.GetKeyDown(KeyCode.Escape))*/
        
            gameIsPaused = !gameIsPaused;
            PauseGame();
        
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            animator.SetBool("gamePause", true);
            animator2.SetBool("gamePause", true);
        }
        else
        {
            Time.timeScale = 1;
            animator.SetBool("gamePause", false);
            animator2.SetBool("gamePause", false);
        }
    }
}
