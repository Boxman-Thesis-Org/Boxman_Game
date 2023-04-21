using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI_Destroy : MonoBehaviour
{
    //Detecting how far it'll come out of range
    [SerializeField] private float currDistance;
    [SerializeField] private float limitDistance = 4f;
    [SerializeField] private Vector3 startingPosition;
    [SerializeField] private Vector3 velocity;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        velocity = this.GetComponent<Rigidbody2D>().velocity;
        //Debug.Log("Velocity: " + velocity);
        //DestroyOutOfRange();
    }

    void DestroyOutOfRange()
    {
        currDistance = Vector3.Distance(this.transform.position, startingPosition);

        if (currDistance > limitDistance)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Destroy(this.gameObject);
    }
}
