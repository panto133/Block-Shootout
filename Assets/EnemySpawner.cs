using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    private Transform spawnedPosition;
    public GameObject Enemy;
    public GameObject spawningEffect;

    private int spawnPlace;
    private float timer = 10f;
    public float spawnTimer = 10f;

    void Update()
    {
        timer += Time.deltaTime;
        spawnPlace = Random.Range(0, spawnPoints.Length);
        if (timer >= spawnTimer)
        {
            spawnedPosition = spawnPoints[spawnPlace];
            StartCoroutine(spawnEnemy());
            timer = 0;
        }
    }

    IEnumerator spawnEnemy()
    {

        Instantiate(spawningEffect, spawnedPosition.position, Quaternion.identity);
        yield return new WaitForSeconds(1f);
        Instantiate(Enemy, spawnedPosition.position, Quaternion.identity);
    }
}
