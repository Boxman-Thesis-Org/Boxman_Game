using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;
using TMPro;

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

    public GameObject boxman;

    PlayerSettings gameplayActions;

    // Start is called before the first frame update
    void Start()
    {
        tutorials = new List<string>();
        actions = new List<string>();
        animator.SetBool("isOpen", true);
        gameplayActions = new PlayerSettings();
        gameplayActions.Player.Move.performed += SwitchActionMapToUI;
    }

    void SwitchActionMapToUI(InputAction.CallbackContext context)
    {
        gameplayActions.Player.Disable();
        gameplayActions.UI.Enable();
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
        boxman.SetActive(false);

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

        if (arrayState < tutorials.Count)
        {
            string tutorial = tutorials[arrayState];
            string action = actions[arrayState];
            animator2.SetInteger("GifState", gifState);
  
            StopAllCoroutines();
            tutorialText.text = "";
            tutorialText.text += tutorial;
            actionText.text = action;
            Debug.Log("Tutorials Index: "+ arrayState + "\n" + "Tutorials Count: "+ tutorials.Count);
        }
        else
        {
            EndTutorial();
        }   
    }

    void OnNext()
    {
        DisplayNextSentence();
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

    void OnPrevious()
    {
        if (arrayState>0)
        {
            DisplayPreviousSentence();
        }
    }

    void EndTutorial()
    {
        //Debug.Log("Ending tutorial.");
        boxman.SetActive(true);

        animator.SetBool("isOpen", false);
        tutorialGroup.blocksRaycasts=false;
    }
}
