using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour {

    private List<WaveData> m_waves;

    void Start() {

    }

    // Update is called once per frame
    void Update() {
    }


    public void setWaves(List<WaveData> waves){ m_waves = waves; }
}
