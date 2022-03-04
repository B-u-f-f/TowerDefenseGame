using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CreateMesh 
{
    public static (Vector3[] meshverts, int[] triangles, Vector2[] uvs)
    genMeshTwoSidedBtwTwoCurves(Vector3[] curveOneVerts, Vector3[] curveTwoVerts){
    
        if(curveOneVerts.Length != curveTwoVerts.Length){
            return (null, null, null);
        }

        int n = curveOneVerts.Length;

        Vector3[] meshverts = new Vector3[2 * n];
        int[] triangles = new int[3 * 2 * (n - 1) * 2];
        Vector2[] uvs = new Vector2[2 * n];


        int meshVertexIndex = 0;
        int triangleIndex = 0;
        for (int i = 0; i < n; i++){
            // create and add points 
            meshverts[meshVertexIndex] = curveOneVerts[i];
            meshverts[meshVertexIndex + 1] = curveTwoVerts[i];
            
            // uv calculation
            float completionPercent = i/(n - 1.0f);
            uvs[meshVertexIndex] = new Vector2(0.0f, completionPercent);
            uvs[meshVertexIndex + 1] = new Vector2(1.0f, completionPercent);

            // create triangles 
            if(i < n - 1){
                triangles[triangleIndex] = meshVertexIndex;
                triangles[triangleIndex + 1] = meshVertexIndex + 2;
                triangles[triangleIndex + 2] = meshVertexIndex + 1;

                triangles[triangleIndex + 3] = meshVertexIndex + 1;
                triangles[triangleIndex + 4] = meshVertexIndex + 2;
                triangles[triangleIndex + 5] = meshVertexIndex + 3;

                triangles[triangleIndex + 6] = meshVertexIndex;
                triangles[triangleIndex + 7] = meshVertexIndex + 1;
                triangles[triangleIndex + 8] = meshVertexIndex + 2;

                triangles[triangleIndex + 9] = meshVertexIndex + 1;
                triangles[triangleIndex + 10] = meshVertexIndex + 3;
                triangles[triangleIndex + 11] = meshVertexIndex + 2;


                triangleIndex += 12;
            }


            meshVertexIndex += 2; 
        }

        return (meshverts, triangles, uvs);
    } 

    public static (Vector3[] meshverts, int[] triangles, Vector2[] uvs)
    genMeshBtwTwoCurves(Vector3[] curveOneVerts, Vector3[] curveTwoVerts){
    
        if(curveOneVerts.Length != curveTwoVerts.Length){
            return (null, null, null);
        }

        int n = curveOneVerts.Length;

        Vector3[] meshverts = new Vector3[2 * n];
        int[] triangles = new int[3 * 2 * (n - 1)];
        Vector2[] uvs = new Vector2[2 * n];


        int meshVertexIndex = 0;
        int triangleIndex = 0;
        for (int i = 0; i < n; i++){
            // create and add points 
            meshverts[meshVertexIndex] = curveOneVerts[i];
            meshverts[meshVertexIndex + 1] = curveTwoVerts[i];
            
            // uv calculation
            float completionPercent = i/(n - 1.0f);
            uvs[meshVertexIndex] = new Vector2(0.0f, completionPercent);
            uvs[meshVertexIndex + 1] = new Vector2(1.0f, completionPercent);

            // create triangles 
            if(i < n - 1){
                triangles[triangleIndex] = meshVertexIndex;
                triangles[triangleIndex + 1] = meshVertexIndex + 2;
                triangles[triangleIndex + 2] = meshVertexIndex + 1;

                triangles[triangleIndex + 3] = meshVertexIndex + 1;
                triangles[triangleIndex + 4] = meshVertexIndex + 2;
                triangles[triangleIndex + 5] = meshVertexIndex + 3;

                triangleIndex += 6;
            }


            meshVertexIndex += 2; 
        }

        return (meshverts, triangles, uvs);
    } 
}
