using UnityEngine;
using TestMySpline;

public class CubicSplineObj : MonoBehaviour {

    private CubicSpline m_spline = new CubicSpline();
    
    [SerializeField] private float m_width;


    public void fitCubicSpline(float[] points, Vector3 start, Vector3 end, Vector3 up){
        m_spline = new CubicSpline();


        int n = points.Length;    

        Vector3 dir = (end - start).normalized;
        Vector3 dir2 = Vector3.Cross(up, dir);
        
        float d = Vector3.Distance(start, end) / (n - 1);


        float[] x = new float[n];
        float[] y = new float[n];
        for(int i = 0; i < n; i++){
            Vector3 p = start + dir * i * d + dir2 * points[i] * m_width;            


            x[i] = p.z;
            y[i] = p.x;


            //Debug.Log(x[i] + " | " + y[i]);
        }

        m_spline.Fit(x, y);

    }


    public Vector3[] samplePoints(int n, Vector3 start, Vector3 end){
        float distBtwPoints = Vector3.Distance(start, end) / (n - 1);
        
        float[] x = new float[n];
        float y = start.y; 

        Vector3 dir = (end - start).normalized;
        x[0] = start.x;
        for(int i = 0; i < n; i++){
            x[i] = (start + dir * i * distBtwPoints).z; 

            //Debug.Log("x " + x[i]);
        }

        float[] z = m_spline.Eval(x);

        Vector3[] points = new Vector3[n];
        for(int i = 0; i < n; i++){
            points[i].x = z[i];
            points[i].y = y;
            points[i].z = x[i];

            //Debug.Log(points[i]);
        }
        
        return points;
    }
}
