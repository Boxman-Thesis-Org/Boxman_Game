using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{ 
   [Header("Boxman's Health Value")]
   [Tooltip("Health values of Boxman")]
   public int health;
   
   PlayerData data;

   [Header("Boxman's Current Position")]
   [Tooltip("Current Position Values of Boxman")]
   public static Vector2 currVector;

   public void Update() {
      health = BoxmanHealth.boxmanHealth; 
   }

   public void SavePlayer()
   {
      SaveSystem.SavePlayer(this);
   }

   public void LoadPlayer()
   {
      SaveSystem.LoadPlayer();
      this.gameObject.transform.position = currVector;

   }
}