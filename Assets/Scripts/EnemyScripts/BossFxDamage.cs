using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossFxDamage : MonoBehaviour
{
    public LayerMask playerLayer;
    public float radius = 0.5f;
    public float damageCount = 10f;

    private PlayerHealth _playerHealth;
    private bool collided;

    void Update()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, playerLayer);

        foreach (var c in hits)
        {
            _playerHealth = c.gameObject.GetComponent<PlayerHealth>();
            collided = true;
        }

        if (collided)
        {
            _playerHealth.TakeDamage(damageCount);
            enabled = false;
        }
    }
}
