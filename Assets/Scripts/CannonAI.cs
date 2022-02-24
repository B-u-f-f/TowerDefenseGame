using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonAI : MonoBehaviour
{

    private GameObject m_target;
    [SerializeField] private float m_rangeRadius;
    [SerializeField] private uint m_fireDelay;    //milliseconds 
    [SerializeField] private uint m_damage;
 
        

    [SerializeField] private Transform m_cannonNozzle;
    [SerializeField] private CannonRange m_cannonRange;
    [SerializeField] private float m_angVelocity;
    private Coroutine m_fireCo;
    //private IEnumerator m_Rotation;

    private int temp_fire;

   
    void Start() {
        // set the range on the collider
        m_cannonRange.GetComponent<SphereCollider>().radius = m_rangeRadius;
        m_fireCo = null;
        m_angVelocity = 5f;
        temp_fire = 0;
        m_fireDelay = 2000;
    }
    
    private IEnumerator cannonFire(){
        while(true){
            Debug.Log("Fire! Fire! Fire! " + m_target.name + " " + temp_fire);
        
            // take away the health of m_target
            
            temp_fire += 1;            

            // wait for delay
            yield return new WaitForSeconds(m_fireDelay / 1000f);

            // shot number
            
        }        
    } 

    // Update is called once per frame
    void Update() {
        // find target  
        
        // if has no target
        if(m_target == null){
            // stop coroutine cannonFire
            m_target = m_cannonRange.getNextTarget();

            // if enemy dead and m_target = null 
            // but m_fireCo != null
            if(m_fireCo != null){
                StopCoroutine(cannonFire());
                m_fireCo = null;
            }

            // if no target is available
            if(m_target == null){               
                return;
            }
        }
        
        // if target moves out of the range
        if(!m_cannonRange.isTargetInRange(m_target)){
            m_target = null;
            // stop the coroutine
            if(m_fireCo != null){
                StopCoroutine(cannonFire());
                m_fireCo = null;
            }
            return;
        }
    
        // if cannon has a target 
        /// direction to the target 
        Vector3 direction = m_target.transform.position - m_cannonNozzle.position;
        /// angle to rotate to face the target
        float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
        /// rotate about axis up through the angle "angle" 
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.up);
        /// rotate
        m_cannonNozzle.rotation = Quaternion.Slerp(m_cannonNozzle.rotation, rotation, m_angVelocity * Time.deltaTime);
        
        // if cannon not firing at someone else then start firing on m_target
        if(m_fireCo == null)
            m_fireCo = StartCoroutine(cannonFire());
    }
}
