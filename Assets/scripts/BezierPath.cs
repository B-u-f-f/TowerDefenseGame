using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierPath : MonoBehaviour {
    private LineRenderer m_lr; 
    private Vector3[] positions;
    private int count; 

    // Start is called before the first frame update
    void Start(){ 
        Transform[] m_points = this.GetComponentsInChildren<Transform>();
        m_lr = this.GetComponent<LineRenderer>();


        if(m_lr == null){
            Debug.LogError("LineRenderer not found.");
            return;
        }
        
        if(m_points.Length <= 2){
            Debug.LogError("Can't generate a path, need atleast 2 points");
            return;
        }
        

        count = m_points.Length - 1;
        positions = new Vector3[count]; 
        for(int i = 1; i <= count; i++){
            positions[i - 1] = m_points[i].position; 
        }

        m_lr.enabled = true;
        m_lr.positionCount = count; 
        m_lr.SetPositions(positions);

    }

    public Vector3 getNextPosition(float t, int pointsPassed){
        Vector3 p = Vector3.zero;
        Vector3 lastPosition = positions[count-1];

        if(t >= 0.0f && t <= 1.0f && pointsPassed < count - 1){
            p = (1 - t) * positions[pointsPassed] + t * positions[pointsPassed + 1];
        }

        return p;
    }

    public int getNumPoints(){ return count; }
}
