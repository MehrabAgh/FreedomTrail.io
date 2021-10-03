using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarTargetController : MonoBehaviour
{

    private CarAIControl car;
    private Transform playerTransform;
    private float stoppingDist = 8;

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
        playerTransform = car.m_Target;
    }

    void Update()
    {
    
        car.m_Driving = (Vector3.Distance(transform.position, playerTransform.position) > stoppingDist);
        
    }
}
