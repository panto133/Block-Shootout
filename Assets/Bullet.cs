using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed;
    public float lifetime;
    public float distance;

    public float damage = 40;

    public LayerMask whatIsSolid;
    public EnemyHealth enemyHealth;

    public GameObject hitEnemyEffect;

    void Start()
    {
        Invoke("DestroyBullet", lifetime);
        
    }
    void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
        if(hitInfo.collider != null)
        {
            if(hitInfo.collider.CompareTag("Enemy"))
            {
                EnemyHealth enemyHealth = hitInfo.collider.GetComponent<EnemyHealth>();
                enemyHealth.TakeDamage(damage);
                Instantiate(hitEnemyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }           
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
