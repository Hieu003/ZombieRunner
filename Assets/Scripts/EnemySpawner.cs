using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    public int xPos;
    public int zPos;
    public int EnemyCount;

    private void Start()
    {
        StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (EnemyCount < 20)
        {
            xPos = Random.Range(20, 120);
            zPos = Random.Range(-50, 80);
            Instantiate(enemy, new Vector3(xPos, 56, zPos), Quaternion.identity);
            yield return new WaitForSeconds(1);
            EnemyCount += 1;
        }
    }
}