using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAI : MonoBehaviour
{

    private GameObject m_target;
    [SerializeField] private float m_rangeRadius;
    [SerializeField] private uint m_fireRate;    //milliseconds 
    [SerializeField] private uint m_damage;
 
        

    [SerializeField] private Transform m_cannonNozzle;
    [SerializeField] private CannonRange m_cannonRange;
    [SerializeField] private float m_angVelocity;
    private IEnumerator m_fireCo;
    //private IEnumerator m_Rotation;

   
    void Start() {
        // set the range on the collider
        m_cannonRange.GetComponent<SphereCollider>().radius = m_rangeRadius;
    }
    
    private IEnumerator cannonFire(){
        yield return null;
    } 

    // Update is called once per frame
    void Update() {
        // find target  
        
        // if has no target
        if(m_target == null){
            m_target = m_cannonRange.getNextTarget();  
            
            // if no target is available
            if(m_target == null){
                return;
            }
        }
        
        // if target moves out of the range
        if(!m_cannonRange.isTargetInRange(m_target)){
            m_target = null;
            return;
        }
    
        // has a target 
        //
        /// direction to the target 
        Vector3 direction = m_target.transform.position - m_cannonNozzle.position;
        /// angle to rotate to face the target
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        /// rotate about axis up through the angle "angle" 
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        /// rotate
        m_cannonNozzle.rotation = Quaternion.Slerp(m_cannonNozzle.rotation, rotation, m_angVelocity * Time.deltaTime);
        
        // start firing
    }
}
