using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public float speed;
    public float damage;
    public float distance;
    public float lifetime;

    private GameObject player;
    private Vector2 target;

    private Vector3 direction;

    RaycastHit2D hitInfo;

    public GameObject hitPlayerEffect;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        target= new Vector2(player.transform.position.x, player.transform.position.y);
        Invoke("DestroyBullet", lifetime);
        direction = (player.transform.position - transform.position).normalized;
    }

    void FixedUpdate()
    {
       hitInfo = Physics2D.Raycast(transform.position, transform.right, distance);
       if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Player"))
            {
                player.GetComponent<PlayerHealth>().TakeDamage(damage);
                Instantiate(hitPlayerEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }

        transform.position += direction * speed * Time.deltaTime;
    }
    void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
