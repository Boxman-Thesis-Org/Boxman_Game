using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    public Tutorial2 tut;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<TutorialManager2>().StartTutorial(tut);
        Debug.Log("Tutorial Start");
    }

}
