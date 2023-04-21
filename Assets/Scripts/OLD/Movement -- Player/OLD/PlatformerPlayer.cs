using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerPlayer : MonoBehaviour
{
    public float speed = 4.5f;

    public float jumpForce;

    //float gravity;

    public bool grounded;

    RaycastGroundCheck groundCheck;

    private BoxCollider box;

    private Rigidbody body;

    private Animator anim;

    MovingPlatform platform;

    // Use this for initialization
    void Start()
    {
        box = GetComponent<BoxCollider>();
        body = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        groundCheck = gameObject.GetComponent<RaycastGroundCheck>();
        platform = null;
        //gravity = 0;
        jumpForce = 20.0f;
    }

    // Update is called once per frame
    void Update()
    {
        float deltaX = Input.GetAxis("Horizontal") * speed;
        Vector3 movement = new Vector3(deltaX, 0, 0);
        body.velocity = movement;
        body.AddForce(Vector3.down * -9.8f * Time.deltaTime);

        if (groundCheck.grounded)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }

        // if (!groundCheck.grounded)
        // {
        //     body.AddForce(Vector3.down * -9.8f * Time.deltaTime);
        // }
        anim.SetFloat("speed", Mathf.Abs(deltaX));

        Vector3 pScale = Vector3.one;
        if (platform != null)
        {
            pScale = platform.transform.localScale;
        }
        if (!Mathf.Approximately(deltaX, 0))
        {
            transform.localScale =
                new Vector3(Mathf.Sign(deltaX) / pScale.x, 1 / pScale.y, 1);
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (groundCheck.grounded)
        {
            platform = hit.gameObject.GetComponent<MovingPlatform>();
        }
        if (platform != null)
        {
            transform.parent = platform.transform;
        }
        else
        {
            transform.parent = null;
        }
    }
}
