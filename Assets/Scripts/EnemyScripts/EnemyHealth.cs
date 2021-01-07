using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    private Image health_Img;
    private void Awake()
    {
        if (tag == "Boss")
        {
            health_Img = GameObject.Find("Health Foreground Boss").GetComponent<Image>();
        }
        else
        {
            health_Img = GameObject.Find("Health Foreground").GetComponent<Image>();
        }
    }

    public void TakeDamage(float amount)
    {
        health -= amount;

        health_Img.fillAmount = health / 100f;
        
        //print("Enemy health: " + health);
        
        if (health <= 0)
        {
            
        }
    }
}//class
