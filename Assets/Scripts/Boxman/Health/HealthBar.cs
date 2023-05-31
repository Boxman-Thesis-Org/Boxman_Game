using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public BoxmanScriptableObject boxman;
    public Slider Healthslider;
    private int health;

    public void Update()
    {
        health = boxman.health;
        Healthslider.value = health;
    }
}

