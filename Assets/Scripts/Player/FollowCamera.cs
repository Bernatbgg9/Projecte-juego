using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    private Vector3 offset = new Vector3(0f, 0f, -1f);
    public float smoothSpeed = 5f;
    private Vector3 velocity = Vector3.zero;
    public Vector3 minValues, maxValues;


    void Start()
    {
        transform.position = target.position;
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = target.position + offset;

        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValues.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValues.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValues.z));

        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothSpeed);
         Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, boundPosition, ref velocity,smoothSpeed);
         transform.position = smoothedPosition;
        //transform.position = target.transform.position + new Vector3(0, 0, -1);

        
    }


}
