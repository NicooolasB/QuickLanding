using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform plane;
    public Vector3 cameraOffset;


    // Update is called once per frame
    void Update()
    {
        transform.position = plane.position + cameraOffset;
    }
}
