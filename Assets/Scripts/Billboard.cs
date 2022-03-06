using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    // camera moves then we update
    void LateUpdate()
    {
        transform.LookAt(transform.position+cam.forward);
    }
}
