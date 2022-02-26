using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour { 
    [SerializeField] private int width;
    [SerializeField] private int height;
    [SerializeField] private float scale;
    

    public bool autoUpdate = false;
    public void display(){
        float[,] noisemap = NoiseGenerator.generatePerlinNoiseMap(width, height, scale);

        MapDisplay md = FindObjectOfType<MapDisplay>(); 
        if(md != null){
            md.DrawNoiseMap(noisemap);
        }
    }

}
