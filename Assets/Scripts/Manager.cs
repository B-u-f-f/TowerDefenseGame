using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour {
    
    [SerializeField] private WaveData[] waves;
    [SerializeField] private Button m_changeWave;
    

    private IEnumerator m_curWave; 
    private WaveManager m_wm;

    private int m_state = 0;
    //private Coroutine m_startWave;

    // Start is called before the first frame update
    void Start() {
        m_wm = GetComponent<WaveManager>();

        m_wm.Waves = waves;

        //changeWave.onClick.AddListener(TaskOnClick);
        m_changeWave.GetComponentInChildren<TextMeshProUGUI>().text = "Start Wave " + (m_wm.getCurrentWave() + 1);
        m_changeWave.onClick.AddListener(() => TaskOnClick());
    }

    void TaskOnClick(){
        if(m_state == 0){
            m_state = 1;

            StartCoroutine(cwaves());
            m_changeWave.GetComponentInChildren<TextMeshProUGUI>().text = "Wave Ongoing!";
            Debug.Log("Start wave: " + m_wm.getCurrentWave());
            Debug.Log("The state is " + m_state);
            
        }else{
            m_state = 0;

            m_changeWave.GetComponentInChildren<TextMeshProUGUI>().text = "Start Wave " + (m_wm.getCurrentWave() + 1);
            Debug.Log("The state is " + m_state);

        }
    }
    
    void Update(){
    }

    IEnumerator cwaves () {
        yield return m_wm.startNextWave();
        yield return m_wm.waitTillEnemiesDie();
        TaskOnClick();
        //yield return StartCoroutine(m_wm.startNextWave());
    }

}
