using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Multiple_Target_Camera : MonoBehaviour
{
    public List<Transform> targets;

    //Movement Variables
    public Vector3 offset;
    public float smoothTime = .5f;
    private Vector3 velocity;

    //Zoom Variables
    public float minZoom = 140f;
    public float maxZoom = 20f;
    public float zoomLimiter = 50f;
    private Camera cam;

    private void Start()
    {
        cam = GetComponent<Camera>();
    }

    //Update Camera position
    private void LateUpdate()
    {
        if(targets.Count == 0)
        {
            return;
        }
        Move();
        Zoom();
    }

    //Move Camera Component
    private void Move()
    {
        Vector3 centerPoint = GetCenterPoint();
        Vector3 newPosition = centerPoint + offset;

        transform.position = newPosition;
        transform.position = Vector3.SmoothDamp(transform.position, newPosition, ref velocity, smoothTime);
    }

    //Zoom Camera Component
    private void Zoom()
    {
        float newZoom = Mathf.Lerp(maxZoom, minZoom, GetGreatestDistance() / zoomLimiter);
        cam.fieldOfView = Mathf.Lerp(cam.fieldOfView, newZoom, Time.deltaTime);
    }


    //Find center point between all characters given to the camera
    private Vector3 GetCenterPoint()
    {
        if( targets.Count == 1 )
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

    //Return the greatest float distance between all characters
    private float GetGreatestDistance()
    {
        var bounds = new Bounds(targets[0].position, Vector3.zero);
        for (int i = 0; i < targets.Count; i++)
        {
            bounds.Encapsulate(targets[i].position);
        }
        if(bounds.size.x > bounds.size.z)
        {
            return bounds.size.x;
        }
        else
        {
            return bounds.size.z;
        }
    }

}
