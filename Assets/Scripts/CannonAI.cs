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

    Quaternion target = Quaternion.Euler(0, -90, 0);
    
        

    [SerializeField] private Transform m_cannonNozzle;
    [SerializeField] private CannonRange m_cannonRange;
    private IEnumerator m_fireCo;
    private IEnumerator m_Rotation;

    private GameObject pivotPoint;
    // private bool flag;
    // Start is called before the first frame update
    //
    void Start() {

        // set the range on the collider
        m_cannonRange.GetComponent<SphereCollider>().radius = m_rangeRadius;

    }

    // IEnumerator startRotating(Vector3 pos){
    

    //     while(transform.forward != pos){
    //         float angle = Vector3.SignedAngle(transform.forward, pos, Vector3.up);
    //         Debug.Log(angle);

    //         target = Quaternion.Euler(0, angle, 0);

    //         this.transform.rotation = Quaternion.Slerp(transform.rotation, target, 0.2f);

    //         yield return null;
    //     }        

    //     flag = true;
    // }

    // Update is called once per frame
    void Update() {
        // is target valid
        // Vector3 pos = m_target.transform.position - transform.position;        
        // pos.Normalize();

        // float angle = Vector3.SignedAngle(transform.forward, pos, Vector3.up);
        // target = Quaternion.Euler(0,angle,0);
        // this.transform.rotation = Quaternion.Slerp(transform.rotation,target,0.3f);

        Vector3 direction = m_target.transform.position - m_cannonNozzle.position;
        float angle = Mathf.Atan2(direction.x,direction.z)*Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle,Vector3.up);
        m_cannonNozzle.rotation = Quaternion.Slerp(m_cannonNozzle.rotation,rotation,5f*Time.deltaTime);
        // rotate nozzle towards the target
        // Vector3 pos = m_target.transform.position - transform.position;
        
        // pos.Normalize();

        // while(transform.forward != pos){
        //     float angle = Vector3.SignedAngle(transform.forward, pos, Vector3.up);
        //     Debug.Log(angle);

        //     target = Quaternion.Euler(0, angle, 0);

        //     this.transform.rotation = Quaternion.Slerp(transform.rotation, target, 0.2f);
        // }


        // if(pos != transform.forward){
        //     if(flag || m_Rotation == null){
        //         m_Rotation = startRotating(pos);
        //         StartCoroutine(m_Rotation);
        //     }  
        //     else{
        //         // still rotating
        //     }          
        // }
             
        


        // co routine check
    }
}
