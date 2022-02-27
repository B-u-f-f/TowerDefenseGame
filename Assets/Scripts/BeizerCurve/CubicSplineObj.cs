using UnityEngine;
// using TestMySpline;

public class CubicSplineObj : MonoBehaviour {

    // private CubicSpline m_spline = new CubicSpline();
    private BSpline m_spline = new BSpline();
    
    [SerializeField] private float m_width;


    public void fitCubicSpline(float[] points, Vector3 start, Vector3 end, Vector3 up){
        // m_spline = new CubicSpline();
        m_spline = new BSpline();


        int n = points.Length;    

        Vector3 dir = (end - start).normalized;
        Vector3 dir2 = Vector3.Cross(up, dir);
        
        float d = Vector3.Distance(start, end) / (n - 1);


        // float[] x = new float[n];
        // float[] y = new float[n];
        
        Vector3[] controlPoints = new Vector3[n];
        for(int i = 0; i < n; i++){
            // Vector3 p = start + dir * i * d + dir2 * points[i] * m_width; 
            
            controlPoints[i] = start + dir * i * d + dir2 * points[i] * m_width;

            // x[i] = p.z;
            // y[i] = p.x;


            //Debug.Log(x[i] + " | " + y[i]);
        }

        //foreach(Vector3 p in controlPoints){
        //    GameObject g = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        //    g.transform.position = p;
        //    g.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        //}

        // m_spline.Fit(x, y);
        m_spline.fit(controlPoints);

    }


    public Vector3[] samplePoints(float spacing, Vector3 start, Vector3 end){
        // float distBtwPoints = Vector3.Distance(start, end) / (n - 1);
        // 
        // float[] x = new float[n];
        // float y = start.y; 

        // Vector3 dir = (end - start).normalized;
        // x[0] = start.x;
        // for(int i = 0; i < n; i++){
        //     x[i] = (start + dir * i * distBtwPoints).z; 

        //     //Debug.Log("x " + x[i]);
        // }

        // float[] z = m_spline.Eval(x);

        // Vector3[] points = new Vector3[n];
        // for(int i = 0; i < n; i++){
        //     points[i].x = z[i];
        //     points[i].y = y;
        //     points[i].z = x[i];

        //     //Debug.Log(points[i]);
        // }
        
        Vector3[] points = m_spline.evenlySpacedPoints(spacing);
        
        //foreach(Vector3 p in points){
        //    GameObject g = GameObject.CreatePrimitive(PrimitiveType.Cube);
        //    g.transform.position = p;
        //    g.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        //}
        
        return points; 
    }
}
