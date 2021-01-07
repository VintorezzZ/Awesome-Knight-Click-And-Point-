using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireShield : MonoBehaviour
{
    private PlayerHealth _playerHealth;
    void Awake()
    {
        _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
    }

    private void OnEnable()
    {
        _playerHealth.Shielded = true;
    }

    private void Start()
    {
        
    }

    private void OnDisable()
    {
        _playerHealth.Shielded = false;
    }
}
