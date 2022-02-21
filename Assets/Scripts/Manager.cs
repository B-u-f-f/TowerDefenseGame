using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    
    [SerializeField] private List<WaveData> waves;

    // Start is called before the first frame update
    void Start() {
        WaveManager wm = GetComponent<WaveManager>();

        wm.setWaves(waves);
    }
}
