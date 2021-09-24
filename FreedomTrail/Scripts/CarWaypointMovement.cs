using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypointMovement : MonoBehaviour
{

    public CarAIControl car;
    private Transform carObj;
    public Transform[] waypoints;
    private int curWpIndx = 0;
    private float dist = 0.5f;
    private bool pathFinished = false;

    private void Start()
    {
        
        carObj = car.gameObject.transform;
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        if(pathFinished)
            return;
       
        car.m_Target = waypoints[curWpIndx];

        // check if we arrived to waypoint
        if(Mathf.Abs(waypoints[curWpIndx].position.magnitude - carObj.position.magnitude) <= dist)
        // then check if it was the last waypoint
            if(curWpIndx + 1 >= waypoints.Length)
                pathFinished = true;
            else
                 curWpIndx ++;

    }
}
