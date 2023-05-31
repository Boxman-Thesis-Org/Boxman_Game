using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;

    public Text dialogueText;

    public Animator animator;

    public Animator animator2;

    private Queue<string> sentences;

    private Queue<string> names;
   
   /*a variable to check if this is the first or second time the button's been pushed
   with the current sentence displayed*/
    private bool nextSent;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        names = new Queue<string>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        animator2.SetBool("isClicked", true);
        animator2.SetBool("convoEnd", false);
        nextSent = true;

        Debug.Log("Starting conversation with" + dialogue.names);

        sentences.Clear();
        names.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }
        foreach (string name in dialogue.names)
        {
            names.Enqueue (name);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        if (sentences.Count <= 0)
        {
            EndDialogue();
            return;
        }
        
        if (!nextSent){
            StopAllCoroutines();
            dialogueText.text = "";
            dialogueText.text += sentence;
            nextSent = true;
        }

       else if(nextSent){
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        nextSent = false;
       }

       Debug.Log(nextSent);
        //dialogueText.text = sentence;
        nameText.text = name;
    }

    IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.08f);
        }
    }

    void EndDialogue()
    {
        Debug.Log("Ending conversation.");
        animator.SetBool("isOpen", false);
        animator2.SetBool("convoEnd", true);
        animator2.SetBool("isClicked", false);
    }

    public void DebugSentence(){
        Debug.Log("Click!");
    }
}
