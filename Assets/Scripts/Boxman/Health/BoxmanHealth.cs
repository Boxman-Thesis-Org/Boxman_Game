using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class BoxmanHealth : MonoBehaviour
{
    [Header("Boxman Scriptable Object Script")]
    [Tooltip("Damage and health values of Boxman")]
    public BoxmanScriptableObject boxman;

    [Header("Boxman Health and Damage")]
    [Tooltip("Damage and health values of Boxman")]
    public static int boxmanHealth;
    public static int boxmanDamage;

    [Header("Boxman and its SpriteRenderer")]
    [Tooltip("Boxman obj and its SpriteRenderer")]
    public GameObject self;
    public static SpriteRenderer sprite;
    
    [Header("Boxman's original beginning position")]
    [Tooltip("Boxman obj and its SpriteRenderer")]
    public Vector3 originalPosition;

    [Header("Boxman's Collision Object")]
    [Tooltip("Detecting obj collision")]
    [SerializeField] private Collision2D enemy;

    [Header("Enemy")]
    [Tooltip("The enemies: Spitter, Seeker, Barricade")]
    public GameObject enemy_obj;
    private AI_Health AI_script;

    private float timer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        AI_script = enemy_obj.GetComponent<AI_Health>();
        self = GameObject.FindWithTag("Player");
        sprite = self.GetComponent<SpriteRenderer>();

        boxman.health = 50;
        boxman.damage = 10;

        originalPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (boxman.health < 0)
        {
            boxman.health = 0;
            resetBoxmanPosition();
        }

        if (boxman.health > 50)
        {
            boxman.health = 50;
        }

        //Timer meant to keep his red color visible
        timer += Time.deltaTime;
        if (timer > 0.3f && !boxman.darkMode)
        {
            sprite.color = new Color (1, 1, 1, 1);
            timer = 0;
        }

        boxmanHealth = boxman.health;
    }


    public void OnCollisionEnter2D(Collision2D collider)
    {
        enemy = collider;

        if (collider.gameObject.tag == "Spitter_Projectiles" || collider.gameObject.tag == "Seeker")
        {
            decreaseHealth();
        }

        if (collider.gameObject.tag == "Death")
        {
            resetBoxmanPosition();
        }
    }

    public void OnCollisionExit2D(Collision2D collider)
    {
        enemy = null;
    }

    public void decreaseHealth()
    {
        boxman.health-=5;
        Debug.Log(boxman.health);
    }

    //Triggers to let player know that Boxman has been impailed
    public void changeColor()
    {
        sprite.color = Color.black;
    }

    public void resetBoxmanPosition()
    {
        this.transform.position = originalPosition;
        boxman.health = 25;
    }
}
