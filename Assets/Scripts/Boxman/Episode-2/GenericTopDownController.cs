using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class GenericTopDownController : MonoBehaviour
{
    [Header("Input")]
    [Tooltip("Current Input Direction")]
    public static Vector2 currVector;

    [Header("Movement")]
    [Tooltip("How fast the player will move")]
    [Range(0f, 40f)]
    public float moveSpeed = 5f;

    [Header("Player Animator")]
    [Tooltip("Animator that contains the animation clips")]
    public Animator animator;

    [Header("Player Related Systems")]
    [Tooltip("Variables related to the player")]
    public static SpriteRenderer sprite;
    [SerializeField] private AudioSource audio;

    //Audio Clips
    [Header("Player Related Audio Clips")]
    [Tooltip("Audio clips to be attached to player movement")]
    public AudioClip audioJump;
    public AudioClip audioAttack;

    //Running Dust Particles
    [Header("Particle System Movement")]
    [Tooltip("Particles meant for player running")]
    public ParticleSystem dust;

    //Scriptable Object for Boxxy
    [Header("Boxman Scriptable Object Script")]
    [Tooltip("Damage and health values of Boxman")]
    public BoxmanScriptableObject boxman;

    //Player Dark Mode
    [Header("Dark Mode Camera")]
    [Tooltip("Black and White Camera")]
    public Camera cam;

    //Dark Mode Indicator
    [Header("Dark Mode Timer Text")]
    [Tooltip("Dark Mode Timer Text")]
    public TMP_Text counterText;
    public CanvasGroup darkCount;
    private float darkTime;

    private Rigidbody2D rb2D;
    Vector2 input;

    /* OLD CODE */
    // [Header("Input")]
    // [Tooltip("Keybinding for moving left/west")]
    // public KeyCode leftButton = KeyCode.A;
    // [Tooltip("Keybinding for moving right/east")]
    // public KeyCode rightButton = KeyCode.D;
    // [Tooltip("Keybinding for moving up/north")]
    // public KeyCode upButton = KeyCode.W;
    // [Tooltip("Keybinding for moving down/south")]
    // public KeyCode downButton = KeyCode.S;

    void Awake()
    {
        // set up rigidbody to accomodate for top down gameplay
        rb2D = GetComponent<Rigidbody2D>();
        rb2D.gravityScale = 0;
        rb2D.interpolation = RigidbodyInterpolation2D.Interpolate;
        rb2D.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        rb2D.freezeRotation = true;

        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        darkTime=5;
        darkCount.alpha = 0f;
        boxman.darkMode = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        bool North = false;
        bool South = false;
        bool East = false;
        bool West = false;

    }

    // Update is called once per frame
    void Update()
    {
        input = currVector.normalized;

        /* OLD CODE */
        // int up = Input.GetKey(KeyCode.W) ? 1 : 0;
        // int down = Input.GetKey(KeyCode.S) ? 1 : 0;
        // int left = Input.GetKey(KeyCode.A) ? 1 : 0;
        // int right = Input.GetKey(KeyCode.D) ? 1 : 0;
        // transform.Translate(input.x * Time.deltaTime * moveSpeed, input.y * Time.deltaTime * moveSpeed, 0);

        animator.SetFloat("Horizontal", currVector.x);
        animator.SetFloat("Vertical", currVector.y);
        animator.SetFloat("Speed", currVector.sqrMagnitude);

        if (boxman.darkMode)
        {
            turnOnDarkMode();
        }

        /*getDirection();*/

        Debug.Log("Magnitude: " + currVector.sqrMagnitude);
    }

    void FixedUpdate()
    {
        rb2D.velocity = input * moveSpeed;
    }

    void getDirection()
    {
        if(currVector.x > 0)
        {
            setDirection("East");
            Debug.Log("East");
        } 
        else if(currVector.x < 0)
        {
            setDirection("West");
            Debug.Log("West");
        }
            
        if (currVector.y > 0)
        {
            setDirection("North");
            Debug.Log("North");
        } 
        else if (currVector.y < 0)
        {
            setDirection("South");
            Debug.Log("South");
        }
    }

    void setDirection(string direction)
    {
        animator.SetBool("East", false);
        animator.SetBool("West", false);
        animator.SetBool("North", false);
        animator.SetBool("South", false);

        animator.SetBool(direction, true);

        // if (currVector.sqrMagnitude > 0.01)
        // {
        //     animator.SetBool(direction, false);
        // }
        // else
        // {
        //     animator.SetBool(direction, true);
        // }
    }

    void OnMove(InputValue inputValue)
    {
        currVector = inputValue.Get<Vector2>();
        CreateDust();
    }

    void OnAttack()
    {
        animator.SetTrigger("Attack");
    }

    void OnDark()
    {
        boxman.darkMode = true;
        darkCount.alpha = 1f;
        darkTime = 5;
        cam.GetComponent<PostProcess>().enabled = true;
    }

    void JumpSound()
    {
        audio.PlayOneShot(audioJump, 0.7F);
    }

    void SwordSound()
    {
        audio.PlayOneShot(audioAttack, 0.5F);
    }

    void CreateDust()
    {
        dust.Play();
        Debug.Log("Triggered?");
    }

    //Damage - 20% boost - since they're all one-hit anyway, does this matter?
    //Speed - 10% boost
    void turnOnDarkMode()
    {
        darkTime -= (Time.deltaTime%60);

        if (darkTime > 0f)
        {
            sprite.color = new Color (0.3f, 0.3f, 0.3f, 1);
            moveSpeed = 8f;
            boxman.health +=25;
            double b = System.Math.Round (darkTime);
            counterText.text = b.ToString();
        }
        else
        {
            darkTime = 0;
            counterText.text = darkTime.ToString();
            boxman.darkMode = false;
            cam.GetComponent<PostProcess>().enabled = false;
            darkCount.alpha = 0f;
        }
    }
}
