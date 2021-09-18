using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float speedMove, speedRotate;
    private void Update()
    {
        transform.position = Vector3.Lerp(transform.position, target.position, Time.deltaTime* speedMove);
        transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * speedRotate);
    }
}
