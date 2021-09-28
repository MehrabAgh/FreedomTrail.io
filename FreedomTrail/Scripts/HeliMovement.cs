using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMovement : MonoBehaviour
{
    public Transform target;
    public float speedMove, speedRotate;
    private Vector3 offset;
    public float height = 15, distance = 20;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
        offset = transform.position - target.position;
       // offset = new Vector3(0,height,0);
    }

    private void Update()
    {

        transform.position = Vector3.Lerp(transform.position, target.position + offset, Time.deltaTime* speedMove);
        
        transform.rotation = Quaternion.LookRotation(Vector3.RotateTowards(
            transform.forward, target.position - transform.position, speedRotate * Time.deltaTime, 0.0f
        ));
       // transform.rotation = Quaternion.Slerp(transform.rotation, target.rotation, Time.deltaTime * speedRotate);
    }
}
