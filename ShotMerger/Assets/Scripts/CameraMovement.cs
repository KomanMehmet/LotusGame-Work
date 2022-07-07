using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public Vector3 targetOffset;


    private void Awake()
    {
        targetOffset = transform.position - target.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position, target.position + targetOffset, 0.125f);
    }
}
