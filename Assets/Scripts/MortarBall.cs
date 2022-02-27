using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarBall : MonoBehaviour
{
    
    private GameObject m_target;
    private float t = 0f;

    [SerializeField] private MortarBallSO m_mortarBallStats;
    [SerializeField] private MortarBallRange m_mortarBallRange;

    private HashSet<GameObject> m_potTargets;
    private uint m_mortarDamage;

    void Start(){
        m_mortarBallRange.GetComponent<SphereCollider>().radius = m_mortarBallStats.m_damageRadius;
    }
    
    private IEnumerator mortarBallMovement(){        

        while(transform.position != m_target.transform.position) {
            transform.position = this.parabolaCurve(transform.position, m_target.transform.position, Vector3.Distance(transform.position, m_target.transform.position)/4, t);
            t += (Time.deltaTime * m_mortarBallStats.m_speed);

            yield return null;
        }

        m_potTargets = m_mortarBallRange.getPotTargets();

        foreach (GameObject gb in m_potTargets){
            if(m_mortarBallRange.isTargetInRange(gb))
                gb.GetComponent<EnemyAI>().reduceHealth(m_mortarDamage);
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

        m_target.GetComponent<EnemyAI>().deathEvent += destroyBall;

        StartCoroutine(mortarBallMovement());
    }
    

    private Vector3 parabolaCurve(Vector3 start, Vector3 end, float height, float t) {
        Func<float, float> f = x => -4 * height * x * x + 4 * height * x;

        var mid = Vector3.Lerp(start, end, t);

        return new Vector3(mid.x, f(t) + Mathf.Lerp(start.y, end.y, t), mid.z);
    }
    

}
