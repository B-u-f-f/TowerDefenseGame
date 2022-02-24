using System;
using UnityEngine;

public class EnemyAI : MonoBehaviour {

    [SerializeField] private EnemySO m_enemy;
    
    //public delegate void onDeathDelegate(GameObject go);
    //public event onDeathDelegate deathEvent; 

    public Action<GameObject> deathEvent; 
    void OnDestroy(){
        if(deathEvent != null){
            deathEvent(this.gameObject);
        }
    }
}
