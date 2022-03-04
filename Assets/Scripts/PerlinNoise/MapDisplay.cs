using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapDisplay : MonoBehaviour
{

    public Renderer renderingPlane; 
    public void DrawNoiseMap(float[,] noisemap){
        int width = noisemap.GetLength(0);
        int height = noisemap.GetLength(1);

        Color[] texColor = new Color[width * height];

        for(int x = 0; x < width; x++){
            for(int y = 0; y < height; y++){
                texColor[y * width + x] = Color.Lerp(Color.black, Color.white, noisemap[x, y]);
            }
        }


        Texture2D tex = new Texture2D(width, height);
        tex.SetPixels(texColor);
        tex.Apply();


        renderingPlane.sharedMaterial.mainTexture = tex;
        renderingPlane.transform.localScale = new Vector3(width, 1, height);
    }
}
