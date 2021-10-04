using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCarTargetController : MonoBehaviour
{

    private CarAIControl car;
    private Transform playerTransform, target;
    //private float stoppingDist = 8;

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
        //playerTransform = GameObject.Find("Player Car").transform;
        //target = car.m_Target;
    }

    private void Update()
    {

       // print("direction" + ((transform.position - playerTransform.position).normalized.z > 0? 1: -1));

      //  target.position = (transform.position + (transform.position - playerTransform.position).normalized) * Vector3.Distance(transform.position, playerTransform.position);

        //car.m_Target = target;
        //car.m_Driving = (Vector3.Distance(transform.position, playerTransform.position) > stoppingDist);
        
    }
}
