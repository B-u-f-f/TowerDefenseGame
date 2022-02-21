using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public EnemyMovement enemy;
    public GameObject spawnPoint;

    private int enemyCount;
    
    void Start()
    {
        enemyCount = 0;
        StartCoroutine(enemySpawn());
    }

    IEnumerator enemySpawn()
    {
        while(enemyCount < 10)
        {
            Vector3 spawnPosition = spawnPoint.transform.position;
            spawnPosition.y += 1;
            EnemyMovement obj = Instantiate(enemy, spawnPosition, Quaternion.identity);
            obj.setBezierPath(spawnPoint.GetComponent<BezierPath>());
            yield return new WaitForSeconds(3f);
            enemyCount += 1;
        }
    }    
}