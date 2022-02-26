using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CubicSplineObj))]
public class CurveRenderer : MonoBehaviour {
    

    [SerializeField] private Transform m_start;
    [SerializeField] private Transform m_end;
    
    [SerializeField] private float thickness = 0.3f;
    [SerializeField] private uint samples = 10;
    [SerializeField] private float scale = 0.3f;
    [SerializeField] private int smoothness  = 10; 

    [field: SerializeField] public bool autoUpdate {get; set;}
    void Start() { 

    }

    public void display(){
        Vector3 start = m_start.position;        
        Vector3 end = m_end.position;



        float[] temp = NoiseGenerator.generatePerlinNoise1D((int)samples, scale);
        
        float[] noise = new float[samples + 2]; 
        noise[0] = 0.0f;
        noise[samples + 1] = 0.0f;

        for(int i = 1; i <= samples; i++){
            noise[i] = 2.0f * (temp[i - 1] - 0.5f);
        }


        // foreach (float n in noise){
        //     Debug.Log(n);
        // }

        CubicSplineObj cso = GetComponent<CubicSplineObj>();
        cso.fitCubicSpline(noise, start, end, Vector3.up);
        Vector3[] sampledPoints = cso.samplePoints(smoothness, start, end); 
        
        var meshData = createMesh(sampledPoints, thickness);
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        
        mesh.Clear();
        mesh.vertices = meshData.verts;
        mesh.triangles = meshData.triangles;                   
    }

    private static (Vector3[] verts, int[] triangles) createMesh(Vector3[] points, float thickness){
        uint numPoints = (uint)points.Length;

        Vector3[] meshVertices = new Vector3[numPoints * 2];
        int[] triangles = new int[ 3 * 2 * (numPoints - 1) ]; 
        
        int meshVertexIndex = 0;
        int triangleIndex = 0;
        Vector3 dir;
        for (int i = 0; i != numPoints; i++){
            // create adjacent points
            
            /// find left direction
            dir = Vector3.zero;
            if(i < numPoints - 1){
                dir += points[i + 1] - points[i]; 
            }

            if(i > 0){
                dir += points[i] - points[i - 1];
            }

            dir.Normalize();
            Vector3 left = -1f * Vector3.Cross(Vector3.up, dir);

            /// create and add points 
            meshVertices[meshVertexIndex] = points[i] + (thickness/2.0f) * left;
            meshVertices[meshVertexIndex + 1] = points[i] - (thickness/2.0f) * left;


            // create triangles 
            if(i < numPoints - 1){
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

        return (meshVertices, triangles); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
