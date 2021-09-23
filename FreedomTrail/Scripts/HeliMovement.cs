using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeliMovement : MonoBehaviour
{
    private Transform target;
    public float speedMove, speedRotate;
    private Vector3 offset;
    public float height = 15, distance = 20;
    private static int heliCount = 0;

    private void Start()
    {
        heliCount = GameObject.FindObjectsOfType<HeliMovement>().Length;
        target = GameObject.Find("Player Car").transform;
       // offset = transform.position - target.position;
        offset = new Vector3(((heliCount -1) * 8 * (heliCount%2==0?1:-1)),height, distance);
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
