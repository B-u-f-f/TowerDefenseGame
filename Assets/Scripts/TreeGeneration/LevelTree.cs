using System.Collections.Generic;
using UnityEngine;
using System;


public class LevelTree {
    public Vector3 position { get; set; }
    
    public GameObject gb { get; set; }
    
    private List<LevelTree> nodes = new List<LevelTree>();
    private bool isLeaf = true;

    
     

    public void addChild(LevelTree t){
        nodes.Add(t);
        isLeaf = false;
    }

    public void applyInPostorder(Func<LevelTree, GameObject> func){
        foreach (LevelTree lt in nodes){
            lt.applyInPostorder(func);
        }

        gb = func(this);
    }
    
}
