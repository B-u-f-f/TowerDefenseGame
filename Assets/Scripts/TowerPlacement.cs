using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerPlacement : MonoBehaviour {
    
    [SerializeField] private Camera m_worldCam;
    [SerializeField] private GameObject[] m_towers;
    [SerializeField] private ToggleController m_toggleController;

    private LayerMask m_layerMask;
    private GameObject m_tower;
    private IEnumerator m_isFollowingObject;
    private GameObject currentTower;

    void Start(){
        m_layerMask = LayerMask.GetMask("placementplane");
        m_isFollowingObject = null;
    }

    void Update() {

        // if(Input.GetMouseButtonDown(0)){
        //     Vector3 mousePosition = Input.mousePosition;            
            
        //     // mousePosition.z = 1.0f;
            
        //     // Vector3 worldMouseCoords = m_worldCam.ScreenToWorldPoint(mousePosition); 
        //     // Debug.Log(worldMouseCoords);
            
        //     Ray r = m_worldCam.ScreenPointToRay(mousePosition);
        //     RaycastHit h; 

        //     if(Physics.Raycast(r, out h, maxDistance: Mathf.Infinity, layerMask: m_layerMask)){
    
        //         // Debug.Log(h.collider.gameObject.name);

        //         if(m_toggleController.getTowerIndex() != -1)
        //             m_tower = m_towers[m_toggleController.getTowerIndex()];
        //         else
        //             return;

        //         Vector3 localMetric = m_tower.transform.localScale / 2;

        //         float sX = localMetric.x;
        //         float sY = localMetric.y;
        //         float sZ = localMetric.z;

        //         Vector3 point = h.point + h.collider.gameObject.transform.up * (0.01f);

        //         Vector3 topLeft = new Vector3(-sX, 0f, -sZ) + point;
        //         Vector3 topRight = new Vector3(sX, 0f, -sZ) + point;
        //         Vector3 bottomLeft = new Vector3(-sX, 0f, sZ) + point;
        //         Vector3 bottomRight = new Vector3(sX, 0f, sZ) + point;

        //         if(hittingSameObjects(m_tower.transform.up, topLeft, topRight, bottomLeft, bottomRight))
        //             Instantiate(m_tower, h.point + new Vector3(0, sY, 0), Quaternion.identity);
                
        //     }
        // }
    }

    public void startFollowingObject(int towerIndex){
        
        if(m_isFollowingObject == null){
            currentTower = m_towers[towerIndex];
            m_tower = Instantiate(m_towers[towerIndex], new Vector3(0, 0, 0), Quaternion.identity);
            m_tower.GetComponent<MeshRenderer>().enabled = false;
            m_isFollowingObject = followingObject();
            StartCoroutine(m_isFollowingObject);
        }
    }

    private IEnumerator followingObject(){
        float sY = m_tower.transform.localScale.y / 2;

        while(true){
            Vector3 mousePosition = Input.mousePosition;
            Ray r = m_worldCam.ScreenPointToRay(mousePosition);
            RaycastHit h;
            if(Physics.Raycast(r, out h, maxDistance: Mathf.Infinity, layerMask: m_layerMask)){
                m_tower.transform.position = h.point + new Vector3(0, sY, 0);
                m_tower.GetComponent<MeshRenderer>().enabled = true;
            }else{
                m_tower.GetComponent<MeshRenderer>().enabled = false;
            }
            if(Input.GetMouseButtonDown(0)){

                if(Physics.Raycast(r, out h, maxDistance: Mathf.Infinity, layerMask: m_layerMask)){
                    if(isObjectOnTopPlane(m_tower, h)){
                        Instantiate(currentTower, h.point + new Vector3(0, sY, 0), Quaternion.identity);
                    }
                }

                m_tower.GetComponent<MeshRenderer>().enabled = false;

                break;                
            }

            yield return null;
        }
    }

    public void stopFollowingObject(){
        if(m_isFollowingObject != null){
            StopCoroutine(m_isFollowingObject);
            m_isFollowingObject = null;
            Destroy(m_tower);
        }
        
    }

    public bool isObjectOnTopPlane(GameObject tower, RaycastHit h){
        Vector3 localMetric = tower.transform.localScale / 2;

        float sX = localMetric.x;
        float sY = localMetric.y;
        float sZ = localMetric.z;

        Vector3 point = h.point + h.collider.gameObject.transform.up * (0.01f);

        Vector3 topLeft = new Vector3(-sX, 0f, -sZ) + point;
        Vector3 topRight = new Vector3(sX, 0f, -sZ) + point;
        Vector3 bottomLeft = new Vector3(-sX, 0f, sZ) + point;
        Vector3 bottomRight = new Vector3(sX, 0f, sZ) + point;

        return hittingSameObjects(tower.transform.up, topLeft, topRight, bottomLeft, bottomRight);
    }

    public bool hittingSameObjects(Vector3 up, Vector3 topLeft, Vector3 topRight, Vector3 bottomLeft, Vector3 bottomRight){

        Ray r1 = new Ray(topLeft, -up);
        RaycastHit h1;
        //Debug.DrawRay(topLeft, -up, Color.red, 100f);
        bool b1 = Physics.Raycast(r1, out h1, maxDistance: Mathf.Infinity, layerMask: m_layerMask);
        //Debug.Log(b1);
        if(!b1)
            return false;        

        Ray r2 = new Ray(topLeft, -up);
        RaycastHit h2;
        //Debug.DrawRay(topLeft, -up, Color.red, 100f);
        bool b2 = Physics.Raycast(r2, out h2, maxDistance: Mathf.Infinity, layerMask: m_layerMask);
        if(!b2)
            return false;

        //Debug.Log(b1);

        Ray r3 = new Ray(bottomLeft, -up);
        RaycastHit h3;
        //Debug.DrawRay(bottomLeft, -up, Color.red, 100f);
        bool b3 = Physics.Raycast(r3, out h3, maxDistance: Mathf.Infinity, layerMask: m_layerMask);
        if(!b3)
            return false;

        // Debug.Log(b1);

        Ray r4 = new Ray(bottomRight, -up);
        RaycastHit h4;
        // Debug.DrawRay(bottomRight, -up, Color.red, 100f);
        bool b4 = Physics.Raycast(r4, out h4, maxDistance: Mathf.Infinity, layerMask: m_layerMask);
        if(!b4)
            return false;

        // Debug.Log(b1);

        if(h1.collider.gameObject == h2.collider.gameObject && h2.collider.gameObject == h3.collider.gameObject && h3.collider.gameObject == h4.collider.gameObject)
            return true;
        else 
            return false;
        

        
    }
}
