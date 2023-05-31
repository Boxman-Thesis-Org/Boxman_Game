using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitLevelTwo : MonoBehaviour
{
    [SerializeField] private CanvasGroup quitMenuGroup;
    [SerializeField] Animator canvasAnimator;
    Color fadeInColor;
    Color fadeOutColor;
    Color startColor;

    // Start is called before the first frame update
    void Start()
    {
      fadeOut();  
    }

       public void fadeIn()
    {
    quitMenuGroup.blocksRaycasts = true;
     canvasAnimator.SetBool("FadeAway", false);
    }

    public void fadeOut()
    {
    quitMenuGroup.blocksRaycasts = false;
     canvasAnimator.SetBool("FadeAway", true);
    }

    public void exitGame()
    {
      Application.Quit();
    }
     
}
