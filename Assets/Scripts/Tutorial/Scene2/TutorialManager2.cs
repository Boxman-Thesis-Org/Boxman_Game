using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

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

    public GameObject boxman;

    PlayerSettings gameplayActions;

    private int gifState;
    private int arrayState;

    // Start is called before the first frame update
    void Start()
    {
        tutorials = new List<string>();
        actions = new List<string>();
        gameplayActions = new PlayerSettings();
        gameplayActions.Player.Move.performed += SwitchActionMapToUI;
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

    void SwitchActionMapToUI(InputAction.CallbackContext context)
    {
        gameplayActions.Player.Disable();
        gameplayActions.UI.Enable();
    }

    public void StartTutorial(Tutorial2 tut)
    {
        boxman.SetActive(false);

        gifState = -1;
        arrayState = -1;

        tutorialGroup.blocksRaycasts=true;
        animator2.SetInteger("GifState",gifState);
        // Debug.Log("Learning about" + tut.actions);
        animator.SetBool("isOpen", true);

        if(tutorials != null)
        {
            tutorials = new List<string>();
            actions = new List<string>();
        }

        Debug.Log(tutorials);

        foreach (string tutorial in tut.tutorials)
        {
            tutorials.Add(tutorial);
        }
        foreach (string action in tut.actions)
        {
            actions.Add(action);
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
            Debug.Log("Tutorials Index: "+ arrayState);
            Debug.Log("Tutorials Count: "+ tutorials.Count);
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
        boxman.SetActive(true);

        Debug.Log("Ending tutorial.");
        animator.SetBool("isOpen", false);
        tutorialGroup.blocksRaycasts=false;
    }
}

