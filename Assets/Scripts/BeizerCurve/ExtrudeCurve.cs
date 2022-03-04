using System;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ExtrudeCurve : MonoBehaviour {
    
    [SerializeField] private float m_width;
    public void extrudeMid(Vector3[] points, Vector3 up, 
            Func<Vector3, float, Vector3> fSideOne, 
            Func<Vector3, float, Vector3> fSideTwo){
        
        

        var verts = createSideVerts(points, m_width, up, fSideOne, fSideTwo);
        var meshdata = CreateMesh.genMeshBtwTwoCurves(verts.leftVerts, verts.rightVerts);

        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        mesh.Clear();
        mesh.vertices = meshdata.meshverts;
        mesh.triangles = meshdata.triangles;
        mesh.uv = meshdata.uvs;
        mesh.RecalculateNormals();
    }

    public void extrudeSide(Vector3[] points, Vector3 up, bool isLeft,
            Func<Vector3, float, Vector3> fSideOne, 
            Func<Vector3, float, Vector3> fSideTwo){
        //int n = verts.Length;
        //Vector3[] verts2 = new Vector3[n];

        //float sign = isLeft ? -1.0f : 1.0f;

        //for(int i = 0; i < n; i++){
        //    Vector3 dir = Vector3.zero;
        //    if(i < n - 1){
        //        dir += verts[i + 1] - verts[i]; 
        //    }

        //    if(i > 0){
        //        dir += verts[i] - verts[i - 1];
        //    }

        //    dir.Normalize();
        //    Vector3 left = sign * Vector3.Cross(up, dir); 

        //    verts2[i] = verts[i] + left * m_width;
        //}

         
        var verts = createSideVerts(points, m_width, up, fSideOne, fSideTwo);
 
        if(isLeft){
            Vector3[] temp = verts.leftVerts;
            verts.leftVerts = verts.rightVerts;
            verts.rightVerts = temp;
        }

        var meshData = CreateMesh.genMeshBtwTwoCurves(verts.leftVerts, verts.rightVerts);
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        mesh.Clear();
        mesh.vertices = meshData.meshverts;
        mesh.triangles = meshData.triangles;
        mesh.uv = meshData.uvs;
        mesh.RecalculateNormals();

    }

     
    private static (Vector3[] leftVerts, Vector3[] rightVerts) 
        createSideVerts (Vector3[] points, float thickness, Vector3 up, 
                Func<Vector3, float, Vector3> fSideOne, Func<Vector3, float, Vector3> fSideTwo) {
        uint numPoints = (uint)points.Length;

        Vector3[] rightVerts = new Vector3[numPoints];
        Vector3[] leftVerts = new Vector3[numPoints];
        
        int meshVertexIndex = 0;
        Vector3 dir;


        for (int i = 0; i != numPoints; i++){ 
            /// find left direction
            dir = Vector3.zero;
            if(i < numPoints - 1){
                dir += points[i + 1] - points[i]; 
            }

            if(i > 0){
                dir += points[i] - points[i - 1];
            }

            dir.Normalize();
            Vector3 left = -1f * Vector3.Cross(up, dir);

            /// create and add points 
            leftVerts[meshVertexIndex] = points[i] + fSideOne(left, thickness);
            rightVerts[meshVertexIndex] = points[i] + fSideTwo(left, thickness);

       
            meshVertexIndex += 1; 
        }

        return (leftVerts, rightVerts); 

    }

}
