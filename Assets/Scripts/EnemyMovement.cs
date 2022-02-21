using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 0.5f;
    
    private float t;
    private int pointsPassed;

    private BezierPath path;
    // Start is called before the first frame update
    void Start() {
        
        pointsPassed = 0;
        t = 0f;
    }

    // Update is called once per frame
    void Update(){

        while(path == null)
            return;
        
        if(pointsPassed < path.getNumPoints() - 1){ 
            Vector3 pos = path.getNextPosition(t, pointsPassed);
            transform.position = new Vector3(pos.x, transform.position.y, pos.z);

            t += speed * Time.deltaTime;

            if(t >= 1.0f){ 
                pointsPassed += 1;
                t = 0f;
            }
        }
    }

    public void setBezierPath(BezierPath p){ path = p; }
    
}