using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private Toggle m_cube;
    [SerializeField] private Toggle m_sphere;
    [SerializeField] private Toggle m_slot2;
    [SerializeField] private Toggle m_slot3;

    private int m_tower = -1;

    // Start is called before the first frame update
    void Start()
    {
        m_cube.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_cube, 0);
        });

        m_sphere.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_sphere, 1);
        });

        m_slot2.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_slot2, 2);
        });

        m_slot3.onValueChanged.AddListener(delegate {
            ToggleValueChanged(m_slot3, 3);
        });
    }

    public void ToggleValueChanged(Toggle change, int towerNo){
        
        m_tower = towerNo;
        // Debug.Log(cube.isOn);
        // Debug.Log(sphere.isOn);
        // Debug.Log(slot2.isOn);
        // Debug.Log(slot3.isOn);
    }

    public int getTowerIndex(){
        return m_tower;
    }
}
