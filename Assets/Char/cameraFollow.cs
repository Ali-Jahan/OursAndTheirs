using System;
using UnityEngine;
using System.Collections;

public class cameraFollow : MonoBehaviour
{
    public Transform char1;
    public Transform char2;
    public float zoomFactor = 1.5f;
    public float followTimeDelta = 0.8f;
    private Camera cam;
    private void Update()
    {
        cam = Camera.main;
        followBoth(cam, char1, char2);
    }

    public void followBoth(Camera cam, Transform t1, Transform t2)
    {
        // Midpoint we're after
        Vector3 midpoint = (t1.position + t2.position) / 2f;

        // Distance between objects
        float distance = (t1.position - t2.position).magnitude;

        // Move camera a certain distance
        Vector3 cameraDestination = midpoint - cam.transform.forward * distance * zoomFactor;

        // // fix distance
        if (distance > 20f)
        {
            distance = 20f;
        }

        if (distance < 15f)
        {
            distance = 15f;
        }
        // Adjust ortho size if we're using one of those
        if (cam.orthographic)
        {
            // The camera's forward vector is irrelevant, only this size will matter
            cam.orthographicSize = distance;
        }
        // You specified to use MoveTowards instead of Slerp
        cam.transform.position = Vector3.Slerp(cam.transform.position, cameraDestination, followTimeDelta);
         
        // Snap when close enough to prevent annoying slerp behavior
        if ((cameraDestination - cam.transform.position).magnitude <= 0.05f)
            cam.transform.position = cameraDestination;
    }
}