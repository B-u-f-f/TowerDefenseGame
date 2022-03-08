using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    private WaveData[] m_waves;
    public WaveData[] Waves {
        set {
            m_waves = value;
        }
    } 
    
    private uint m_curWave = 0;
    
    [SerializeField] private EnemySpawn[] m_spawnPoints;

    public IEnumerator startNextWave(){
        WaveData wd = m_waves[m_curWave];        
        for (uint i = 0; i != wd.NumEnemies; i++){
            foreach (EnemySpawn sPoint in m_spawnPoints){
                sPoint.spawnEnemy(wd.Enemy);
            }

            yield return new WaitForSeconds(wd.WaitTime);
        }

        m_curWave += 1;
    }


}
