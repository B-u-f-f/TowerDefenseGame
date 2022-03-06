using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    
    [SerializeField] private WaveData[] waves;
    

    private IEnumerator m_curWave; 
    private WaveManager m_wm;
    // Start is called before the first frame update
    void Start() {
        m_wm = GetComponent<WaveManager>();

        m_wm.Waves = waves;
        StartCoroutine(cwaves());
    }
    
    void Update(){
    }

    IEnumerator cwaves () {
        yield return StartCoroutine(m_wm.startNextWave());
        yield return StartCoroutine(m_wm.startNextWave());
    }

}
