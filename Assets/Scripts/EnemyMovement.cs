using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
    [SerializeField] private float m_speed = 0.5f;
    private float errorCorrection = 0f;
    
    private BezierPath path;
    public BezierPath Path {
        set {
            path = value;
        }
    }

    void OnTriggerEnter(Collider collider){
        if(collider.gameObject.name == "Plane"){
            Debug.Log(gameObject.name + " was triggered by " + collider.gameObject.name);
            errorCorrection += 0.2f;
        }
    }
 
    public void startFollow() {
        StartCoroutine(startFollowCour());
    } 

    private IEnumerator startFollowCour(){
        foreach (Vector3 pos in path.Positions){
            yield return move(m_speed, pos);
        }
    }


    private IEnumerator move(float speed, Vector3 dest){        
        dest.y += errorCorrection;
        while(transform.position != dest){
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }
    }
}
