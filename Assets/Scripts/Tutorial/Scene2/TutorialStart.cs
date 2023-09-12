using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialStart : MonoBehaviour
{
    public Tutorial2 tut;
    // Start is called before the first frame update
    void Update()
    {
        FindObjectOfType<TutorialManager2>().StartTutorial(tut);
        this.gameObject.SetActive(false);
        Debug.Log("Tutorial Start");
    }
}
