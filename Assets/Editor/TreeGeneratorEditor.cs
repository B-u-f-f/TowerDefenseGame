using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(RandomTreeGenerator))]
public class TreeGeneratorEditor : Editor {
    public override void OnInspectorGUI() {
        RandomTreeGenerator trgen = (RandomTreeGenerator) target;

        //if(DrawDefaultInspector() && crv.autoUpdate){
        //    trgen.display();
        //}

        DrawDefaultInspector();
        if(GUILayout.Button("Generate")){
            trgen.display();
        }


        if(GUILayout.Button("Clear")){
            trgen.clearChildren();
        }

    }

}
