using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class TutorialManager : MonoBehaviour
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
        animator.SetBool("isOpen", true);
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
            //Debug.Log("Out of tutorial items!");
            EndTutorial();
             return;
         }
        
    }

    public void StartTutorial(Tutorial tut)
    {
        gifState = -1;
        arrayState = -1;

        tutorialGroup.blocksRaycasts=true;
        animator2.SetInteger("GifState",gifState);
        animator.SetBool("isOpen", true);
         
        if(tutorials != null){
        tutorials.Clear();
        actions.Clear();
        }

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
        //Debug.Log("Ending tutorial.");
        animator.SetBool("isOpen", false);
        tutorialGroup.blocksRaycasts=false;
    }
}
