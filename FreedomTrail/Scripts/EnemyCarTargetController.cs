using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarTargetController : MonoBehaviour
{

    private CarAIControl car;

    private void Start()
    {
        car = GetComponent<CarAIControl>();
        
        /*
        if(Vector3.Distance(transform.position, CarWaypointMovement.leftTarget.position) < Vector3.Distance(transform.position, CarWaypointMovement.rightTarget.position))
        {
            car.m_Target = CarWaypointMovement.leftTarget;
        }
        else 
        {
            car.m_Target = CarWaypointMovement.rightTarget;
        }
        */
        
        car.m_Target = GameObject.Find("Player Car").transform;
    }

    void Update()
    {
        
    }
}
