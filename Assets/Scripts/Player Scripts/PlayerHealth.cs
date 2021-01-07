using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health = 100f;

    private bool isShielded;

    private Animator anim;

    private Image health_Img;
    public bool Shielded
    {
        get => isShielded;
        set => isShielded = value;
    }

    private void Awake()
    {
        anim = GetComponent<Animator>();
        health_Img = GameObject.Find("Health Icon").GetComponent<Image>();
    }

    public void TakeDamage(float amount)
    {
        if (!isShielded)
        {
            health -= amount;

            health_Img.fillAmount = health / 100f;
            
            if (health <= 0f) 
            {
                // player dies     
                anim.SetBool("Death", true);

                if (!anim.IsInTransition(0) && anim.GetCurrentAnimatorStateInfo(0).IsName("Death") &&
                    anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.95f)  
                {
                    // PLAYER DEAD
                    // DESTROY PLAYER
                    Destroy(gameObject);
                }
            }
        }
    }

    public void HealPlayer(float healAmount)
    {
        health += healAmount;

        if (health > 100f)
            health = 100f;

        health_Img.fillAmount = health / 100f;
    }
}
