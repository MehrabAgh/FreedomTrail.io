using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buildingGenerator : MonoBehaviour
{

    public GameObject building;
    public Transform parent;
    public int distance = 10;

    void Start()
    {
        StartCoroutine(add());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator add()
    {
        while (true)
        {
            GameObject go = Instantiate(building, transform.position + (transform.right * distance), transform.rotation);
            go.transform.Rotate(Vector3.right, -90);
            go.transform.parent = parent;
            go = Instantiate(building, transform.position + (-transform.right * distance), transform.rotation);
            go.transform.Rotate(Vector3.right, -90);
            go.transform.parent = parent;
            yield return new WaitForSeconds(1.0f);
        }
    }
}
