using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    //Player Movement
    private float horizontal;
    private float speed = 4f;
    private float jumpingPower = 24f;
    private bool isFacingRight = true;

    //Player Dark Mode
    [Header("Dark Mode Camera")]
    [Tooltip("Black and White Camera")]
    public Camera cam;

    //Input from current controller/keyboard/device
    //Values are: -1, 0, -1
    //Acts similarly to Input.GetAxisRaw("Horizontal");
    [Header("Player's Movement")]
    [Tooltip("How fast the player will move")]
    public static Vector2 currVector;

    //Player Obj Variables
    [Header("Player Related Systems")]
    [Tooltip("Variables related to the player")]
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Animator anim;
    [SerializeField] private AudioSource audio;
    public static SpriteRenderer sprite;

    //Audio Clips
    [Header("Player Related Audio Clips")]
    [Tooltip("Audio clips to be attached to player movement")]
    public AudioClip audioWalk;
    public AudioClip audioJump;
    public AudioClip audioAttack;

    //Running Dust Particles
    [Header("Particle System Movement")]
    [Tooltip("Particles meant for player running")]
    public ParticleSystem dust;
    
    //Pause Control??
    //public PauseControl pause;

    //Scriptable Object for Boxxy
    [Header("Boxman Scriptable Object Script")]
    [Tooltip("Damage and health values of Boxman")]
    public BoxmanScriptableObject boxman;

    //NO
    [Header("Dark Mode Projectile")]
    [Tooltip("Dark Mode Projectiles")]
    public GameObject projectile;
    public Transform projectileSpawnPoint;

    [Header("Dark Mode Timer Text")]
    [Tooltip("Dark Mode Timer Text")]
    public TMP_Text counterText;
    public CanvasGroup darkCount;
    private float darkTime;

    [Header("Currently Selected Projectile")]
    [Tooltip("Boxman Oriented")]
    [SerializeField] private GameObject boxmanProjectile;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
        sprite = GetComponent<SpriteRenderer>();
        //pause = new PauseControl();
        darkTime=5;
        darkCount.alpha = 0f;
        boxman.darkMode = false;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(rb.velocity.x));

        if (boxman.darkMode)
        {
            turnOnDarkMode();
        }
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(currVector.x * speed, rb.velocity.y);
    }

    public bool IsGrounded()
    {
        return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
    }

    public void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Floor" || collider.gameObject.tag == "BoxObject")
        {
            anim.SetTrigger("Land");
        }
    }

    private void Flip(Vector2 playerPos)
    {   
        if(!PauseControl.gameIsPaused)
        {
            if (isFacingRight && playerPos.x < 0f || !isFacingRight && playerPos.x > 0f)
            {
                isFacingRight = !isFacingRight;
                Vector3 localScale = transform.localScale;
                localScale.x *= -1f;
                transform.localScale = localScale;
            }
       }
    }

    void JumpSound()
    {
        audio.PlayOneShot(audioJump, 0.7F);
    }

    void WalkSound()
    {
        //audio.PlayOneShot(audioWalk, 0.8F);
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

    void OnMove(InputValue inputValue)
    {
        currVector = inputValue.Get<Vector2>();
        Flip(currVector);
        CreateDust();
    }

    void OnJump()
    {
        if (IsGrounded() && !PauseControl.gameIsPaused) //Start the Jump
        {
            anim.SetTrigger("Jump");
            CreateDust();
            rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 0.75f);
            // rb.velocity = new Vector2(rb.velocity.x, jumpingPower * 1.25f);
        }

        // if (rb.velocity.y > 0f) //Bring to earth -- may not be needed
        // {
        //     rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y * 0.5f);
        // }
    }

    void OnAttack()
    {
        if (rb.velocity.x == 0) //Is moving (i.e. not idle)
        {
            Debug.Log("idle attack");
            anim.SetTrigger("Attack");
        }

        if (rb.velocity.y != 0) //Is jumping
        {
            Debug.Log("jump Attack");
            anim.SetTrigger("jumpAttack");
        }
        else //Is not jumping
        {
            Debug.Log("walk attack");
            anim.SetTrigger("swingAttack");
        }
    }

    void OnDark()
    {
        boxman.darkMode = true;
        darkCount.alpha = 1f;
        darkTime = 5;
        cam.GetComponent<PostProcess>().enabled = true;
    }

    //Damage - 20% boost - since they're all one-hit anyway, does this matter?
    //Speed - 10% boost
    //We're not doing projectiles e_e
    void turnOnDarkMode()
    {
        darkTime -= (Time.deltaTime%60);

        if (darkTime > 0f)
        {
            sprite.color = new Color (0.3f, 0.3f, 0.3f, 1);
            speed = 6f;
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
        
        //Unused but temporarily here
        //boxman.damage = 0;
        //sendProjectile(); 
    }

    void sendProjectile()
    {
        boxmanProjectile = Instantiate(projectile, projectileSpawnPoint.transform.position, Quaternion.identity);
        // boxmanProjectile.GetComponent<Rigidbody2D>().velocity 
    }
}
