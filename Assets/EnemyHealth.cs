using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float startingEnemyHealth = 100f;
    public float currentEnemyHealth;

    public GameObject deathEffect;

    void Awake()
    {
        currentEnemyHealth = startingEnemyHealth;
    }

    void Update()
    {
        if (currentEnemyHealth <= 0f)
        {
            Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    public void TakeDamage(float damage)
    {
        currentEnemyHealth -= damage;
    }
}
