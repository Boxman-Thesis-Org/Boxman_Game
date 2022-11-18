using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Pathway : MonoBehaviour
{
    //Stick Figure Character
    public GameObject player;

    //Enemy Figure Variables
    private SpriteRenderer _enemySprite;
    private Animator _enemyAnimator;
    private float speed;
    
    //Enemy Positions
    public GameObject pointA;
    public GameObject pointB;

    private Vector2 _currPoint;

    //Meant for Enemy to follow main player
    private float distance;

    private bool stopFollowTemp = false;

    // Start is called before the first frame update
    void Start()
    {
        speed = 2.0f;
    }

    // Update is called once per frame
    void Update()
    {
        MoveInPaths();
        FollowPlayer();
    }

    void FollowPlayer()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (distance < 4)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            stopFollowTemp = true;
            
            //Below is ideal for the top-down scene
            //transform.rotation = Quaternion.Euler(Vector3.forward*angle);
        }
        else
        {
            stopFollowTemp = false;
        }
    }

    void MoveInPaths()
    {
        Vector3 movePathSlightNeg = new Vector3(-3,0,0);
        Vector3 movePathSlightPos = new Vector3(3,0,0);

        if (!stopFollowTemp)
        {
            if (this.transform.position.x >= pointA.transform.position.x)
            {
                _currPoint = pointB.transform.position + movePathSlightNeg;
                //Debug.Log("Move to B");
            }
            
            if (this.transform.position.x <= pointB.transform.position.x)
            {
                _currPoint = pointA.transform.position + movePathSlightPos;
                //Debug.Log("Move to A");
            }

            transform.position = Vector2.MoveTowards(this.transform.position, _currPoint, speed * Time.deltaTime);
        }
    }
}
