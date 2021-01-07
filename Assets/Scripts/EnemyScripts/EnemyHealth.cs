using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float health = 100f;

    private void Awake()
    {
        
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        
        print("Enemy health: " + health);
        
        if (health <= 0)
        {
            
        }
    }
}//class
