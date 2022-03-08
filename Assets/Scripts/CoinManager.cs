using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private LevelSO m_levelSO;
    [SerializeField] private ToggleController m_toggleController;
    
    private int m_coins;

    void Awake(){
        m_coins = m_levelSO.m_initialCoins;
    }

    public void decereaseAmount(int amount){
        m_coins -= amount;
        Debug.Log(m_coins);

        if(m_coins <= 0){
            m_toggleController.setIsThereMoney(false);
        }
    }
    
    public void increaseAmount(int amount){
        m_coins += amount;
        Debug.Log(m_coins);

        if(m_coins > 0){
            m_toggleController.setIsThereMoney(true);
        }
    }
}
