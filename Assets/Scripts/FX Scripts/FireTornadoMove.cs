using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireTornadoMove : MonoBehaviour
{
    public LayerMask enemyLayer;
    public float radius = 0.5f;
    public float damageCount = 10f;
    public GameObject fireExplosion;

    private EnemyHealth _enemyHealth;
    private bool collided;
    
    private float speed = 3f;
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        transform.rotation = Quaternion.LookRotation(player.transform.forward);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckForDamage();
    }

    void Move()
    {
        transform.Translate(Vector3.forward * (speed * Time.deltaTime));
    }
    
    private void CheckForDamage()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius, enemyLayer);

        foreach (var c in hits)
        {
            if (c.isTrigger)
                continue; // don't need to detect that

            _enemyHealth = c.gameObject.GetComponent<EnemyHealth>();
            collided = true;
        }

        if (collided)
        {
            _enemyHealth.TakeDamage(damageCount);
            Vector3 temp = transform.position;
            temp.y += 2f;
            Instantiate(fireExplosion, temp, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
