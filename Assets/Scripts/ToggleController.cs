using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleController : MonoBehaviour
{
    [SerializeField] private Toggle cube;
    [SerializeField] private Toggle sphere;

    // Start is called before the first frame update
    void Start()
    {
        cube.onValueChanged.AddListener(delegate {
            ToggleValueChanged(cube);
        });
    }

    public void ToggleValueChanged(Toggle change)
    {

        ColorBlock col =  change.colors;
        
        if(cube.isOn)
            col.normalColor = Color.red;
        else
            col.normalColor = Color.blue;
        
        change.colors = col;
        Debug.Log(cube.isOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
