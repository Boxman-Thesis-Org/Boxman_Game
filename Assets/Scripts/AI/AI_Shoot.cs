using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Shoot : MonoBehaviour
{
    //List of Projectiles]
    [Header("List of Prefab Projectiles")]
    [Tooltip("Prefab Projectiles")]
    public List<GameObject> projectiles;

    //Side note for me: SerializeField just makes it show up in the inspector
    //Projectiles
    [Header("Currently Selected Projectile")]
    [Tooltip("Randomly selected")]
    [SerializeField] private GameObject spitterProjectile1;
    [SerializeField] private GameObject spitterProjectile2;

    public enum Direction 
    {
        Left, Right, Up, Down
    };

    [Header("Projectile Direction")]
    [Tooltip("Left,Right,Up,Down")]
    public Direction dir;

    [Header("Projectile Velocity Direction")]
    [Tooltip("Velocity Direction")]
    [SerializeField] private Vector2 goRight = new Vector2(5.0f, 0.0f);
    [SerializeField] private Vector2 goUp = new Vector2(0.0f, 2.0f);
    
    //Projectile's Info
    [Header("Projectile's Spawn Point")]
    [Tooltip("Based on empty game object")]
    public GameObject projectileSpawnPoint;

    //Wait time for coroutine
    [Header("Coroutine time space")]
    [Tooltip("Determined waiting time")]
    [SerializeField] private int waitingTime = 3;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ThrowFirstProjectile());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator ThrowFirstProjectile()
    {
        int randomize = (int)Random.Range(0.0f, 3.0f);
        spitterProjectile1 = Instantiate(projectiles[randomize], projectileSpawnPoint.transform.position, Quaternion.identity);

        if (dir == Direction.Left)
        {
            spitterProjectile1.GetComponent<Rigidbody2D>().velocity = -goRight;
        }
        else if (dir == Direction.Right)
        {
            spitterProjectile1.GetComponent<Rigidbody2D>().velocity = goRight;
        }
        else if (dir == Direction.Up) //Up or Down does not currently work
        {
            spitterProjectile1.GetComponent<Rigidbody2D>().velocity = goUp;
        }
        else if (dir == Direction.Down)
        {
            spitterProjectile1.GetComponent<Rigidbody2D>().velocity = -goUp;
        }

        yield return new WaitForSeconds(0.2f);

        //Seems like if Vector3.left is multiplied by anything, it turns the velocity to zero
        //If increase is needed, might need to figure out how to increase the X value OR make a Vector3 value
        //spitterProjectile.GetComponent<Rigidbody>().velocity = Vector3.left;
        
        StartCoroutine(ThrowSecondProjectile());
    }

    private IEnumerator ThrowSecondProjectile()
    {
        int randomize = (int)Random.Range(0.0f, 3.0f);
        spitterProjectile2 = Instantiate(projectiles[randomize], projectileSpawnPoint.transform.position, Quaternion.identity);
        
        if (dir == Direction.Left)
        {
            spitterProjectile2.GetComponent<Rigidbody2D>().velocity = -goRight;
        }
        else if (dir == Direction.Right)
        {
            spitterProjectile2.GetComponent<Rigidbody2D>().velocity = goRight;
        }
        else if (dir == Direction.Up)
        {
            spitterProjectile2.GetComponent<Rigidbody2D>().velocity = goUp;
        }
        else if (dir == Direction.Down)
        {
            spitterProjectile2.GetComponent<Rigidbody2D>().velocity = -goUp;
        }

        //Seems like if Vector3.left is multiplied by anything, it turns the velocity to zero
        //If increase is needed, might need to figure out how to increase the X value OR make a Vector3 value
        //spitterProjectile.GetComponent<Rigidbody>().velocity = Vector3.left;
        yield return new WaitForSeconds(waitingTime);
        StartCoroutine(ThrowFirstProjectile());
    }
}
