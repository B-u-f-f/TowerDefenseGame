using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerPlacement : MonoBehaviour {
    
    [SerializeField] private Camera m_worldCam;
    private LayerMask m_layerMask;

    void Start(){
        m_layerMask = LayerMask.GetMask("placementplane");
    }

    void Update() {
        if(Input.GetMouseButtonDown(0)){
            Vector3 mousePosition = Input.mousePosition;
            
            // mousePosition.z = 1.0f;
            
            // Vector3 worldMouseCoords = m_worldCam.ScreenToWorldPoint(mousePosition); 
            // Debug.Log(worldMouseCoords);
            // 
            // 
            
            Ray r = m_worldCam.ScreenPointToRay(mousePosition);
            RaycastHit h; 

            if(Physics.Raycast(r, out h, maxDistance: Mathf.Infinity, layerMask: m_layerMask)){
                Debug.DrawLine(r.origin, h.point); 
                Debug.Log(h.collider.gameObject.name);
                GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
                g.transform.position = h.point;                                    }


        }
    }
}
