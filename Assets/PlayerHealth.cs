using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float startPlayerHealth = 1000f;
    public float currentPlayerHealth;

    public GameObject deathEffect;

    PlayerMovement playerMovement;
    Enemy enemyMovement;
    EnemyShooting enemyShooting;
    void Awake()
    {
        currentPlayerHealth = startPlayerHealth;
    }

    void Update()
    {
        if (currentPlayerHealth <= 0)
        {
            Destroy(gameObject);
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            playerMovement.enabled = false;
            enemyMovement.enabled = false;
            enemyShooting.enabled = false;
        }
    }
    public void TakeDamage(float damage)
    {
        currentPlayerHealth -= damage;
    }
}
