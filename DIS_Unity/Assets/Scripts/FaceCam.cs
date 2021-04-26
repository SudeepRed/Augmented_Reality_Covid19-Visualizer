using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class FaceCam : MonoBehaviour
{
    Transform cam;
    Vector3 targetangle = Vector3.zero;
    // Get the main camera transform
    void Start()
    {
        cam = Camera.main.transform;
    }

    // make the transfrom lookAt the camera
    void Update()
    {
        transform.LookAt(cam);
        targetangle = transform.localEulerAngles;
        //targetangle.x = 0;
        targetangle.z = 0;
        
        transform.localEulerAngles = targetangle;
    }
}
