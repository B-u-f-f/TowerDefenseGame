using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonRange : MonoBehaviour {

    private SphereCollider m_col;
    private HashSet<GameObject> m_potTargets; 

    void OnTriggerEnter(Collider other){

        if(other.gameObject.tag != "Enemy") return;

        //Debug.Log(other.gameObject.name);
        m_potTargets.Add(other.gameObject);
    }


    void OnTriggerExit(Collider other){
        if(other.gameObject.tag != "Enemy") return;
        m_potTargets.Remove(other.gameObject);
    }

    // Start is called before the first frame update
    void Start() {
        m_col = GetComponent<SphereCollider>(); 

        if(m_col == null){
            Debug.Log("SphereCollider not found");
        }

        m_potTargets = new HashSet<GameObject>();
    }


    // void Update(){
    //     GameObject tar = getNextTarget(); 
    //     if(tar != null)
    //         Debug.Log("Target: " + tar.name);
    // }
    
    public bool isTargetInRange(GameObject g) {
        return m_potTargets.Contains(g);
    }


    public GameObject getNextTarget(){
        if(m_potTargets.Count == 0){
            return null;
        }

        GameObject min = null;
        float dist = float.MaxValue;
        float temp;
        foreach (GameObject gb in m_potTargets){
            temp = Vector3.Distance(gb.transform.position, transform.position);  
            if(temp < dist){
                dist = temp;
                min = gb;
            } 
        }

        if(!m_potTargets.Contains(min)){
            if(m_potTargets.Count > 0){
                min = getNextTarget();
            }
            else {
                min = null;
            }
        }

        return min;
    }
}
