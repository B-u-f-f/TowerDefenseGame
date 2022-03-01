using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBall : MonoBehaviour
{
    
    private GameObject m_target;
    //private float t = 0f;

    [SerializeField] private MortarBallSO m_mortarBallStats;
    [SerializeField] private MortarBallRange m_mortarBallRange;
    //[SerializeField] private GameObject m_mortarBallPath;
    [SerializeField] private GameObject pathStart;
    [SerializeField] private GameObject pathTop;
    [SerializeField] private GameObject pathEnd;

    private HashSet<GameObject> m_potTargets;
    private uint m_mortarDamage;
    private Vector3 m_fixedLastEnemyPosition;

    private float distanceEnemy;
    private Vector3 directionEnemy;


    


    //private Transform pathTop;
    //private Transform pathEnd;

    void Start(){
        m_mortarBallRange.GetComponent<SphereCollider>().radius = m_mortarBallStats.m_damageRadius;

        // initializing the positions of the path
        
        // putting the starting point of the path
        //m_mortarBallPath.transform.GetChild(1).position = transform.position;

        pathStart.transform.position = transform.position;
        
        // putting the height of the path
        //pathTop = m_mortarBallPath.transform.GetChild(1);

        // putting the position of the end of the path
        //pathEnd = m_mortarBallPath.transform.GetChild(2);
    }
    
    private IEnumerator mortarBallMovement(){
        
        //m_mortarBallPath.transform.GetChild(1).position = new Vector3(Mathf.Abs(transform.position.x - m_fixedLastEnemyPosition.x)/2, Vector3.Distance(transform.position, m_fixedLastEnemyPosition)/2, Mathf.Abs(transform.position.z - m_fixedLastEnemyPosition.z)/2);
        
        distanceEnemy = Vector3.Distance(m_fixedLastEnemyPosition, transform.position);
        directionEnemy = (m_fixedLastEnemyPosition - transform.position).normalized;
        //m_mortarBallPath.transform.GetChild(0).position = (transform.position + (directionEnemy * distanceEnemy / 2f)) + Vector3.up * distanceEnemy / 2f;
        //m_mortarBallPath.transform.GetChild(2).position = m_fixedLastEnemyPosition;

        pathTop.transform.position = (transform.position + (directionEnemy * distanceEnemy / 2f)) + Vector3.up * distanceEnemy / 2f;
        pathEnd.transform.position = m_fixedLastEnemyPosition;

        //this.GetComponent<ParabolaController>().initializeParabolaFly();
        //this.GetComponent<ParabolaController>().FollowParabola();
        


        while(transform.position != m_fixedLastEnemyPosition) {
            //transform.position = this.parabolaCurve(transform.position, m_fixedLastEnemyPosition, Vector3.Distance(transform.position, m_fixedLastEnemyPosition)/4, t);
            //t += (Time.deltaTime * m_mortarBallStats.m_speed);

            //this.GetComponent<ParabolaController>().updateParabola();

            GetComponent<ParabolaController>().enabled = true;

            yield return new WaitForSeconds(2f);
        }

        m_potTargets = m_mortarBallRange.getPotTargets();

        foreach (GameObject gb in m_potTargets){
            if(m_mortarBallRange.isTargetInRange(gb))
                gb.GetComponent<EnemyAI>().reduceHealth(m_mortarDamage);
                Debug.Log("Damage done!");
        }

        Destroy(this.gameObject, 0.2f);
    }

    
    void OnDestroy(){
        if(m_target != null)
            m_target.GetComponent<EnemyAI>().deathEvent -= destroyBall;
    }

    private void destroyBall(GameObject g) {
        Destroy(this.gameObject, 0.2f);
    }

    public void moveMortarBall(GameObject target, uint mortarDamage){
        m_target = target;
        m_mortarDamage = mortarDamage;
        m_fixedLastEnemyPosition = target.transform.position;

        m_target.GetComponent<EnemyAI>().deathEvent += destroyBall;

        StartCoroutine(mortarBallMovement());
    }
    

    private Vector3 parabolaCurve(Vector3 start, Vector3 end, float height, float t) {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }
    

}
