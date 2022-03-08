using System;
using UnityEngine;

[Serializable]
public class WaveData {
    [SerializeField] private uint  m_numEnemies; 
    public uint NumEnemies {
        get {
            return m_numEnemies;
        }
    }

    [SerializeField] private float m_waitTime;
    public float WaitTime {
        get {
            return m_waitTime;
        }
    }
    
    [SerializeField] private EnemyMovement m_enemy;
    public EnemyMovement Enemy {
        get {
            return m_enemy;
        }
    } 

    public WaveData(uint numEnemies, float waitTime, EnemyMovement enemy){
        m_numEnemies = numEnemies; 
        m_waitTime = waitTime;
        m_enemy = enemy;
    }
}
