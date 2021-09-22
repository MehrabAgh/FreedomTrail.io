using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointRoadGenerator : MonoBehaviour
{
     private Vector3[] waypoints;
     public Transform WaypointHolder;
     public float roadWidth = 10;
     private List<Vector3> points = new List<Vector3>();
     public GameObject pointer;

    private void Start()
    {
        waypoints = new Vector3[WaypointHolder.transform.childCount];
        for (int i = 0; i < WaypointHolder.transform.childCount; i++)
        {
            waypoints[i] = WaypointHolder.transform.GetChild(i).position;
        }
        CalculatePoints();
        VisualizePoints();
    }

    void Update()
    {
        
    }
    
    void VisualizePoints()
    {
        foreach (var item in points)
        {
            Instantiate(pointer, item, Quaternion.identity);
        }
    }

    private void CalculatePoints()
    {
        for (int i = 0; i < waypoints.Length - 1; i++)
        {

            //Vector3 rPoint = new Vector3(x: waypoints[i].x + roadWidth / 2, y: 0, z: waypoints[i].z);
            //Vector3 lPoint = new Vector3(x:waypoints[i].x  -roadWidth / 2, y: 0, z: waypoints[i].z);

            float angle = Vector3.Angle(waypoints[i + 1] - waypoints[i], -Vector3.forward);

            Vector3 rPoint = new Vector3((Mathf.Cos(angle) * roadWidth) + waypoints[i].x , 0, (Mathf.Sin(angle) * roadWidth) + waypoints[i].z);
            Vector3 lPoint = new Vector3((Mathf.Cos(angle) * -roadWidth) - waypoints[i].x , 0, (Mathf.Sin(angle) * roadWidth) + waypoints[i].z);

            Debug.Log(angle);
            points.Add(rPoint);
            points.Add(lPoint);

        }
    }
}
