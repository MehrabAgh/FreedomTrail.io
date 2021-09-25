using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Random_Building : MonoBehaviour 
{
    public float floorHight, baseHight , roofHight;      //in order to instanciate each floors model on top of each other we need the hieght
    public GameObject[] baseObj;    //the first floor that has shops and stuff
    public GameObject[] building;    //from 1 floor to floor n
    public GameObject[] roofsObj;    //the roof :)
    public int model;   //it holds the hieght of different models and represents them as options
    public Material[] MatMod1;  //the material options
   [Range(0,5)] public int selMat = 0;  //the sellected and aplied material
    [Range(0,25)]public int story;   //determines how many soreis the building has

    enum ColliderMode { BaseOnly, BasenRoof, All }
    [SerializeField]ColliderMode sellected = ColliderMode.All;
    [SerializeField]bool isRandom , Colliders;
    public bool first = true , hasBuilt;      //the first time the prefab enters the scene 
    int chechForUpdate;          //check if the building setting has changed


    void Start()
    {
       // MeshCollider mCol = gameObject.AddComponent<MeshCollider>();
        

        chechForUpdate = story;


       // gameObject.GetComponent<MeshRenderer>().sharedMaterials[0] = MatMod1[selMat];

        switch (model)
        {
            case 0:
                {
                    floorHight = 3;
                    baseHight = 0;
                    roofHight = 0;
                    break;
                }
        }

    }

	void Update ()
    {
        if(Application.isEditor && !Application.isPlaying)
        {

            if (isRandom)
            {
                story = Random.Range(2, 18);
                selMat = Random.Range(0, 4);
                chechForUpdate = story;
                isRandom = false;
                Destruct();
                Build();
            }

            if (chechForUpdate != story)
            {
                Destruct();
                Build();
            }

            if (first && !hasBuilt)
            {
                Destruct();
                Build();
            }
               

            if (Colliders && !first)
            {
                Destruct();
                Build();
            }
               
        }
    }


    void Build()
    {
        Debug.Log("Build");

        first = false;
        hasBuilt = true;
        chechForUpdate = story;

        Vector3 nextFloor = (new Vector3(0, baseHight, 0));
        GameObject BaseGO = Instantiate(baseObj[model], transform.position, transform.rotation);
        BaseGO.transform.parent = this.transform;
     
        
        int i = story;
        while (i > 0)
        {
           GameObject FloorGO = Instantiate(building[model], transform.position + nextFloor, transform.rotation);
            nextFloor.y += (floorHight);
            //Debug.Log("floor:" + i);
            i--;

            FloorGO.transform.parent = this.transform;
            FloorGO.GetComponent<MeshRenderer>().material = MatMod1[selMat];

           //add collider
            
            if(Colliders && !first && sellected == ColliderMode.All)
            FloorGO.AddComponent<BoxCollider>();
        }

        //roof
        GameObject RoofGO = Instantiate(roofsObj[model], transform.position + nextFloor - new Vector3(0,floorHight,0), transform.rotation);
        RoofGO.transform.parent = this.transform;
        //roof

        //collider
        if (Colliders && !first)
        {
            BoxCollider col = BaseGO.AddComponent<BoxCollider>();

            if(sellected != ColliderMode.BaseOnly)
            RoofGO.AddComponent<BoxCollider>();
        }
        //collider



        if (!first)
            Colliders = false;
    }

    void Destruct()
    {
        int i = this.transform.childCount; 
        while(i > 0)
        {
            GameObject DGO = this.transform.GetChild(i -1).gameObject;
            DestroyImmediate(DGO);

            i--;
        }
    }
}
