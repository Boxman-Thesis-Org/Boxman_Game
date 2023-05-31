using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxmanSword : MonoBehaviour
{
    [Header("Enemy Object")]
    [Tooltip("Enemy of Boxman")]
    public GameObject enemy;
    private AI_Health AI_script;

    [Header("Boxman Scriptable Object Script")]
    [Tooltip("Damage and health values of Boxman")]
    public BoxmanScriptableObject boxman;

    public Transform explosion;

    // Start is called before the first frame update
    void Start()
    {
        AI_script = enemy.GetComponent<AI_Health>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.tag == "Seeker")
        {
            Instantiate(explosion, collider.transform.position, collider.transform.rotation);
            AI_script.decreaseSeekerHealth();
            
            if (AI_script.seekerHealth <= 0)
            {
            
                Destroy(collider.gameObject);
                boxman.health+=5;

            }
        }

        if (collider.gameObject.tag == "Barricade")
        {
            AI_script.decreaseBarricadeHealth();

            if (AI_script.barricadeHealth <= 0)
            {
                Destroy(collider.gameObject);
                boxman.health+=1;
            }
        }

        if (collider.gameObject.tag == "SpitterProjectiles")
        {
            Destroy(collider.gameObject);
        }
    }
}
