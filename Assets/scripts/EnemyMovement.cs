using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    public float speed = 0.1f;
    
    private float t;
    private int pointsPassed;

    [SerializeField] private BezierPath path;
    // Start is called before the first frame update
    void Start() {
        if(path == null){
            Debug.Log("Path Not Found!");
        }

        pointsPassed = 0;
        t = 0f;
    }

    // Update is called once per frame
    void Update(){
        
        if(pointsPassed < path.getNumPoints() - 1){ 
            Vector3 pos = path.getNextPosition(t, pointsPassed);
            transform.position = pos;


            t += speed * Time.deltaTime;

            if(t >= 1.0f){ 
                pointsPassed += 1;
                t = 0f; 
            }
        }
    }
    
}
