using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] private EnemySO enemyData;
    
    private BezierPath path;
    public BezierPath Path {
        set {
            path = value;
        }
    }

    //void OnTriggerStay(Collider collider){
    //    if(collider.gameObject.tag == "Path"){
    //        Debug.Log(gameObject.name + " was triggered by " + collider.gameObject.name);

    //        // transform.position += Vector3.up * 0.2f;
    //    }
    //}
 
    public void startFollow() {
        StartCoroutine(startFollowCour());
    } 

    private IEnumerator startFollowCour(){
        foreach (Vector3 pos in path.Positions){
            yield return move(enemyData.speed, new Vector3(pos.x, transform.position.y, pos.z));
        }


        Destroy(this, 0.2f);
    }


    private IEnumerator move(float speed, Vector3 dest){        
        while(transform.position != dest){
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }
    }
}
