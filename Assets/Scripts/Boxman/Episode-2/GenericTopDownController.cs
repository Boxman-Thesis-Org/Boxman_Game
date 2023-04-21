using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

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
    }

    // Start is called before the first frame update
    void Start()
    {

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
    }

    void FixedUpdate()
    {
        rb2D.velocity = input * moveSpeed;
    }

    void OnMove(InputValue inputValue)
    {
        currVector = inputValue.Get<Vector2>();
    }
}
