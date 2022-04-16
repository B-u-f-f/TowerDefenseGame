using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour {
    
    [SerializeField] private WaveData[] waves;
    [SerializeField] private Button m_changeWave;
    [SerializeField] private GameObject m_inventory;
    [SerializeField] private ToggleController m_toggleController;
    [SerializeField] private TextMeshProUGUI m_TMPCoinAmount;
    [SerializeField] private LevelSO m_lvlSO;
    

    private IEnumerator m_curWave; 
    private WaveManager m_wm;

    private int m_state = 0;
    //private Coroutine m_startWave;

    // Start is called before the first frame update
    void Start() {
        m_wm = GetComponent<WaveManager>();

        m_lvlSO.Coins = 1000;

        m_TMPCoinAmount.text = m_lvlSO.Coins + " coins";

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
            m_changeWave.interactable = false;
            m_inventory.SetActive(false);
            //Debug.Log("Start wave: " + m_wm.getCurrentWave());
            //Debug.Log("The state is " + m_state);
            
        }else{
            m_state = 0;

            m_changeWave.interactable = true;
            m_inventory.SetActive(true);
            m_changeWave.GetComponentInChildren<TextMeshProUGUI>().text = "Start Wave " + (m_wm.getCurrentWave() + 1);
            //Debug.Log("The state is " + m_state);

        }
    }


    IEnumerator cwaves () {
        yield return m_wm.startNextWave();
        yield return m_wm.waitTillEnemiesDie();
        TaskOnClick();
    }

    public void changeCurrency(int amt){
        m_lvlSO.changeCoins(amt);
        m_TMPCoinAmount.text = m_lvlSO.Coins + " coins";

        if(m_lvlSO.Coins <= 0){
            m_toggleController.setIsThereMoney(false);
            
        }else{
            m_toggleController.setIsThereMoney(true);
        }
    } 
    
}
