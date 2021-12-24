using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerationController : MonoBehaviour
{
    [SerializeField]
    private Transform cameraTransform;

    public void AccelerationUpdate(Vector3 a, float dt)
    {
        Vector3 dx = (0.5f * a * dt * dt);
        cameraTransform.position += dx;
    }
}
