using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathSpots : MonoBehaviour
{
    public GameObject player;
    private BoxmanHealth boxman_script;
    
    // Start is called before the first frame update
    void Start()
    {
        boxman_script = player.GetComponent<BoxmanHealth>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            boxman_script.resetBoxmanPosition();
        }
    }
}
