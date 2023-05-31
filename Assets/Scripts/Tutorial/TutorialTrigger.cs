using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialTrigger : MonoBehaviour
{
    public Tutorial tut;

    public Animator animator;

  public void TriggerTutorial()
    {
        FindObjectOfType<TutorialManager>().StartTutorial(tut);
        this.gameObject.SetActive(false);
    }
}
