using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastGroundCheck : MonoBehaviour
{
    public float distanceToCheck = 0.5f;

    public bool grounded;

    public RaycastHit hit;

    // Update is called once per frame
    void Update()
    {
        Ray ray = new Ray(transform.position, Vector3.down);
        grounded = Physics.Raycast(ray, out hit, distanceToCheck);
    }
}
