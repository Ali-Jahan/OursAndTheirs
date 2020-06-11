using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class multitargetcamera : MonoBehaviour
{
    public List<Transform> targets;
    public float smoothTime = 0.5f;
    public Vector3 offset;
    public float maxZoom = 21f;
    public float minZoom = 10f;
    public float zoomLimit = 20f;
    private Camera cam;
    private Vector3 velocity;

    private void Start()
    {
        cam = Camera.main;
    }

    public void addTarget(GameObject obj)
    {
        targets.Add(obj.transform);
    }
    private void LateUpdate()
    {
        if (targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }

    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetMostDistance() / zoomLimit);
        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, newZoom, Time.deltaTime);
        GetMostDistance();
    }

    float GetMostDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.size.x;
    }
    private void Move()
    {
        Vector3 center = GetCenterPoint();
        Vector3 newPos = center + offset;
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothTime);
    }
    private Vector2 GetCenterPoint()
    {
        if (targets.Count == 1)
        {
            return targets[0].position;
        }

        var bounds = new Bounds(targets[0].position, Vector3.zero);

        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }

        return bounds.center;
    } 

}
