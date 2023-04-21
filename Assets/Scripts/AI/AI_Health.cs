using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Health : MonoBehaviour
{
    [Header("Enemy Health")]
    [Tooltip("Health values of all enemies")]
    public int spitterHealth;
    public int seekerHealth;
    public int barricadeHealth;

    [Header("Boxman Health Script")]
    [Tooltip("Damage and health values of Boxman")]
    public GameObject player;
    private BoxmanHealth boxman_script;

    [Header("Boxman Scriptable Object Script")]
    [Tooltip("Damage and health values of Boxman")]
    public BoxmanScriptableObject boxman;

    // Start is called before the first frame update
    void Start()
    {
        spitterHealth = 10;
        seekerHealth = 5;
        barricadeHealth = 20;
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
            boxman.health-=5;
            boxman_script.changeColor();
        }
    }

    public void decreaseSpitterHealth()
    {
        spitterHealth-=10;
    }
    
    public void decreaseBarricadeHealth()
    {
        barricadeHealth-=10;
    }
    
    public void decreaseSeekerHealth()
    {
        seekerHealth-=10;
    }
}
