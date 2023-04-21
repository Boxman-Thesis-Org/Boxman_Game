//using this code: https://forum.unity.com/threads/simple-ui-animation-fade-in-fade-out-c.439825/

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuitMenu : MonoBehaviour
{
    [SerializeField] private CanvasGroup quitMenuGroup;
    [SerializeField] Animator canvasAnimator;
    Color fadeInColor;
    Color fadeOutColor;
    Color startColor;
 

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

    
