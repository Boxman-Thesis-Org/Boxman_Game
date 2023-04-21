using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* The code is from Brackey's Save tutorial 
https://www.youtube.com/watch?v=XOjd_qU2Ido&list=RDCMUCYbK_tjZ2OrIZFBvU6CCMiA&start_radio=1&t=961s&ab_channel=Brackeys
And the comments are my own */

/*This isn't going to be attached to any game object as a component, nor 
will it use any of the standard Unity methods, so the Monobehavior base
class doesn't need to be called */

/* [System.Serializable] Marks this class as convertable to bytes and C++ so it can be redirected
into another coding environment or compiled into a different language by Unity */

[System.Serializable]
public class PlayerData
{

  public int health;
  public float[] position;

/* PlayerData (Player player) is a constructor for this class. It defines 
the kinds of data values that are being saved (string, int, bool, etc)
This constructor also defines the starting values that will be saved 
(Like starting at 50 hp instead of 0 or 25) */

/*Player player is calling the Player script from the video example
but you could use any script with the necessary data as long as it's attached to
the Player gameobject aka Boxman 

This is because the position array is calling the transform that this script is
attached to, so it's gotta be the boxman transform to get boxman's current
location */
  
  public PlayerData (Player player) 
  {
    health = player.health;

    position = new float[3];
    position[0] = player.transform.position.x;
    position[1] = player.transform.position.y;
    position[2] = player.transform.position.z;
  }

}
