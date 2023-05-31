using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager2 : MonoBehaviour
{
     public TMP_Text actionText;

    public TMP_Text tutorialText;

    public Animator animator;

    public Animator animator2;

    public Button backButton;

    public CanvasGroup tutorialGroup;

    private List<string> actions;

    private List<string> tutorials;

    private int gifState;
    private int arrayState;

    // Start is called before the first frame update
    void Start()
    {
        tutorials = new List<string>();
        actions = new List<string>();
    }

    void Update() 
    {
        if (arrayState<=0)
        {
           backButton.gameObject.SetActive(false);
        }
        else{
            backButton.gameObject.SetActive(true);
        }

        if (arrayState>=tutorials.Count)
        {
            EndTutorial();
            return;
        }
        
    }

    public void StartTutorial(Tutorial2 tut)
    {
        tutorialGroup.blocksRaycasts=true;
        animator.SetBool("isOpen", true);
        gifState = -1;
        arrayState = -1;
        animator2.SetInteger("GifState",gifState);
        Debug.Log("Learning about" + tut.actions);

        tutorials.Clear();
        actions.Clear();

        foreach (string tutorial in tut.tutorials)
        {
            tutorials.Add (tutorial);
        }
        foreach (string action in tut.actions)
        {
            actions.Add (action);
        }
        DisplayNextSentence();
    }

     public void DisplayNextSentence()
    {
        gifState+=1;
        arrayState+=1;
        string tutorial = tutorials[arrayState];
        string action = actions[arrayState];
        animator2.SetInteger("GifState", gifState);
  
            StopAllCoroutines();
            tutorialText.text = "";
            tutorialText.text += tutorial;
            actionText.text = action;
            Debug.Log("Tutorials Index: "+ arrayState);
            Debug.Log("Tutorials Count: "+ tutorials.Count);
    }

    public void DisplayPreviousSentence()
    {
        gifState-=1;
        arrayState-=1;
        string tutorial = tutorials[arrayState];
        string action = actions[arrayState];
        animator2.SetInteger("GifState", gifState);
        
            StopAllCoroutines();
            tutorialText.text = "";
            tutorialText.text += tutorial;
            actionText.text = action;
            Debug.Log(arrayState);

    }

        void EndTutorial()
    {
        Debug.Log("Ending tutorial.");
        animator.SetBool("isOpen", false);
        tutorialGroup.blocksRaycasts=false;
    }
}

