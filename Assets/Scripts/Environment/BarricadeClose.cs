using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarricadeClose : MonoBehaviour
{
    public GameObject barricade;

    [SerializeField] private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = barricade.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            anim.SetTrigger("CloseDoor");
        }

        if (collider.gameObject.tag == "Seeker")
        {
            collider.isTrigger = true;
        } 
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Seeker")
        {
            collider.isTrigger = false;
        } 
    }
}
