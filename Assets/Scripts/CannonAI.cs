using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAI : MonoBehaviour
{

    [SerializeField] private GameObject m_target;
    [SerializeField] private float m_vAngleMax;   // Radians
    [SerializeField] private float m_rangeRadius;
    [SerializeField] private uint m_fireRate;    //milliseconds 
    [SerializeField] private uint m_damage;
    
        

    [SerializeField] private Transform m_cannonNozzle;
    [SerializeField] private CannonRange m_cannonRange;
    private IEnumerator m_fireCo;
    // Start is called before the first frame update
    //
    void Start() {

        // set the range on the collider
        m_cannonRange.GetComponent<SphereCollider>().radius = m_rangeRadius;
    }

    // Update is called once per frame
    void Update() {
        // is target valid  
        

        // rotate nozzle towards the target


        // co routine check
    }
}
