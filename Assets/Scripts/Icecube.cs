using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBall : MonoBehaviour
{

    public float speed = 20f;
    public float slowAmount = 10f; // Factor by which the enemy's speed will be reduced
    public float slowDuration = 3f; // Duration for which the enemy will be slowed
    public GameObject slowEffect; // Particle effect for slow effect

    private void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Slow the enemy
            SlowEnemy(other.transform);

            // Destroy the iceball
            DestroyIceBall();
            Debug.Log("Iceball collided with an enemy. Enemy slowed and iceball destroyed.");
        }
    }

    void SlowEnemy(Transform enemyTransform)
    {
        EnemyMovement enemyMovement = enemyTransform.GetComponent<EnemyMovement>();
        if (enemyMovement != null)
        {
            enemyMovement.ApplySlow(slowAmount, slowDuration);

            // Instantiate slow effect
            if (slowEffect != null)
            {
                Instantiate(slowEffect, enemyTransform.position, Quaternion.identity);
            }
        }
    }

    void DestroyIceBall()
    {
        // Destroy the iceball
        Destroy(gameObject);
    }
}