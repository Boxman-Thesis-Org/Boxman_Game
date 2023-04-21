using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject MPause;

    public GameObject OPause;

    public Animator animator;

    public Animator animator2;

    public void MainPause()
    {
        MPause.SetActive(true);
        OPause.SetActive(false);
        animator.SetBool("gamePause", true);
    }

    public void OptionsPause()
    {
        MPause.SetActive(false);
        OPause.SetActive(true);
        animator2.SetBool("gamePause", true);
        //OPause.transform.position = new Vector3(200, 502, 0);
    }
}
