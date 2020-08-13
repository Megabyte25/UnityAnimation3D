using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;

    public float maxSpeed;
    public float slowDistance;
    public float arrivalDistance;

    void FixedUpdate()
    {
        Vector3 direction = target.transform.position - transform.position + offset;
        float distance = direction.magnitude;

        if (distance > slowDistance)
        {
            transform.Translate(direction.normalized * maxSpeed * Time.fixedDeltaTime, Space.World);
        }
        else if (distance > arrivalDistance)
        {
            float percentage = (distance - arrivalDistance) / (slowDistance - arrivalDistance);
            transform.Translate(direction.normalized * maxSpeed * percentage * Time.fixedDeltaTime, Space.World);
        }
    }
}
