using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/BoxmanScriptableObject", order = 1)]
public class BoxmanScriptableObject : ScriptableObject
{
    //Boxman Variables
    public int health;
    public int damage;

    //Boxman Dark Mode
    public bool darkMode;
}
