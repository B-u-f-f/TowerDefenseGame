using System.Collections;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {

    [SerializeField] private EnemySO enemyData;
    // if deathState is 1 then it means the coins will be dropped
    // if the deathState is 0 then the coins will not be dropped
    private int deathState = 1;
    
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
        
        setDeathState(0);
        Destroy(this.gameObject, 0.2f);
    }

    public void setDeathState(int value){
        deathState = value;
    }

    public int getDeathState(){
        return deathState;
    }

    void OnDestroy(){

        if(deathState == 1){
            Instantiate(enemyData.currencyPrefab, transform.position, Quaternion.identity);
            FindObjectOfType<Manager>().changeCurrency(enemyData.currencyAward);
        }        
    }


    private IEnumerator move(float speed, Vector3 dest){        
        while(transform.position != dest){
            transform.position = Vector3.MoveTowards(transform.position, dest, speed * Time.deltaTime);
            yield return null;
        }
    }
}
