using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private Transform m_spawnPoint;
    
 /*    IEnumerator enemySpawn()

    {
        while(enemyCount < 10)
        {
            Vector3 spawnPosition = spawnPoint.position;
            spawnPosition.y += 1;
            EnemyMovement obj = Instantiate(enemy, spawnPosition, Quaternion.identity);
            obj.Path = spawnPoint.GetComponent<BezierPath>();
            obj.startFollow();

            enemyCount += 1;
            yield return new WaitForSeconds(3f);
        }
    }   */ 


    public EnemyMovement spawnEnemy(EnemyMovement enemy){
        Vector3 spawnPosition = m_spawnPoint.position;
        spawnPosition.y += 1;
        EnemyMovement obj = Instantiate(enemy, spawnPosition, Quaternion.identity);
        obj.Path = m_spawnPoint.GetComponent<BezierPath>();
        obj.startFollow();
        return obj;
    }
}
