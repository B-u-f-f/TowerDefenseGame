using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBall : MonoBehaviour
{
    private GameObject m_target;

    [SerializeField] private CannonBallSO cannonBallStats;

    private IEnumerator cannonBallMovement(){

        while(transform.position != m_target.transform.position){
            transform.position = Vector3.MoveTowards(transform.position, m_target.transform.position, cannonBallStats.m_speed);

            yield return null;
        }

        Destroy(this.gameObject, 0.2f);
    }

    void OnDestroy(){
        if(m_target != null)
            m_target.GetComponent<EnemyAI>().deathEvent -= destroyBall;
    }

    private void destroyBall(GameObject g){
        Destroy(this.gameObject, 0.2f);
    }

    public void moveCannonBall(GameObject target){
        m_target = target;

        m_target.GetComponent<EnemyAI>().deathEvent += destroyBall;

        StartCoroutine(cannonBallMovement());
    }
}
