using System;
using UnityEngine;

[Serializable]
public class WaveData {
    [SerializeField] private uint  m_numEnemies; 
    [SerializeField] private float m_secBtwSpawn;    

    public WaveData(uint numEnemies, float secBtwSpawn){
        m_numEnemies = numEnemies; 
        m_secBtwSpawn = secBtwSpawn;
    }
}
