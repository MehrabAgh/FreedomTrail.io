using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public Transform Target ,heliGun;
    public Transform[] PivGun;
    public GameObject Ammo, Ammo2;
    private bool waiting;
    public float Power = 1500, DelayStart;
    private float Delay;
    private void Start()
    {
        Target = FindObjectOfType<PlayerMovement>().transform;
    }
    private void Update()
    {
        if (gameObject.name != "heli")
        {
            TargetLook(Target,transform);
        }
        else
        {
            TargetLook(Target,heliGun);
        }
        AttackShoot();
    }
   
    public void TargetLook(Transform Target , Transform piv)
    {
       piv.transform.LookAt(Target);
    }
    public void AttackShoot()
    {
        if (waiting)
        {
            Delay -= Time.deltaTime;
            if (Delay <= 0)
            {
                waiting = false;
            }
        }
        if (!waiting)
        {
            for (int i = 0; i < PivGun.Length; i++)
            {
                Ammo2 = Instantiate(Ammo, PivGun[i].position, PivGun[i].rotation);
                Ammo2.GetComponent<Rigidbody>().AddForce(transform.forward * Power);
            }
            Delay = DelayStart;
            waiting = true;
        }
    }
}
