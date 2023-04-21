using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxTesting : MonoBehaviour
{
    private float _startingPos; //This is the starting position of the sprites.
    private float _lengthOfSprite; //This is the length of the sprites.

    [Header("Background Parallax Scroll Value")]
    [Tooltip("Selected Value of Parallax Scroll")]
    [Range(0.0f, 1.0f)]
    public float AmountOfParallax; //This is amount of parallax scroll. 

    [Header("Main Camera")]
    [Tooltip("Episode 1 Cam")]
    public Camera MainCamera; //Reference of the camera.

    private void Start()
    {
        //Getting the starting X position of sprite.
        _startingPos = transform.position.x;
        //Getting the length of the sprites.
        _lengthOfSprite = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    private void Update()
    {
        Vector3 Position = MainCamera.transform.position;
        float Temp = Position.x * (1 - AmountOfParallax);
        float Distance = Position.x * AmountOfParallax;

        Vector3 NewPosition = new Vector3(_startingPos + Distance, transform.position.y, transform.position.z);

        transform.position = NewPosition;

        if (Temp > _startingPos + (_lengthOfSprite / 2))
        {
            _startingPos += _lengthOfSprite;
        }
        else if (Temp < _startingPos - (_lengthOfSprite / 2))
        {
            _startingPos -= _lengthOfSprite;
        }
    }
}
