using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarWaypointMovement : MonoBehaviour
{

    private CarAIControl car;
    private Transform carObj;
    public Transform waypointHolder;
    public Transform[] waypoints;
    private int curWpIndx = 0;
    private float dist = 0.5f;
    private bool pathFinished = false;

   /* public static Transform leftTarget, rightTarget;
    private void Awake()
    {
        leftTarget = GameObject.Find("left follow target").transform;
        rightTarget = GameObject.Find("right follow target").transform;
    }*/

    private void Start()
    {
        car = GetComponent<CarAIControl>();
        carObj = car.gameObject.transform;
        waypointHolder = GameObject.Find("WayPointHolder").transform;
        waypoints = new Transform[waypointHolder.transform.childCount];
        for (int i = 0; i < waypointHolder.transform.childCount; i++)
        {
            waypoints[i] = waypointHolder.transform.GetChild(i);
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
