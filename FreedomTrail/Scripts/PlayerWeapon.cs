using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{

    public Transform barrel; // shooting pivot as mehrab call it :)
    public GameObject bullet; // player bullet prefab
    public float projectionSpeed = 1000;

    public ParticleSystem muzzleFX;

    public enum weapone {rifle, shotgun, machinegun, minigun};
    public weapone curWeapone;

    private float[] FPS = {1.2f, 0.6f, 7, 15};
    private float[] delays; 
    private float nexttimetofire;
    private int burstshotCount = 0;

    private void Start()
    {
        delays = new float[4];
        for (int i = 0; i < 4; i++)
        {
            delays[i] = 1 / FPS[i];
        }
    }


    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) & curWeapone == weapone.minigun)
        {
           minigunShoot();
        }
        
        if (Input.GetKey(KeyCode.Mouse0) & curWeapone == weapone.machinegun)
        {
           machineGunShoot();
        }
        if (Input.GetKey(KeyCode.Mouse0) & curWeapone == weapone.shotgun)
        {
           shotgunShoot();
        }
        if (Input.GetKey(KeyCode.Mouse0) & curWeapone == weapone.rifle)
        {
           burstShoot();
        }

          nexttimetofire -= Time.deltaTime;
    }

    private void minigunShoot() // miningun shot
    {
        if(nexttimetofire <= 0)
       {

            nexttimetofire = delays[3];
            GameObject projectile = Instantiate(bullet, barrel.position + (barrel.forward * 2), barrel.rotation);
            projectile.GetComponent<Rigidbody>().velocity = barrel.forward * projectionSpeed;
            muzzleFX.Play();
       }    
    }

    private void machineGunShoot() // machinegun shot
    { 
        if(nexttimetofire <= 0)
       {

            nexttimetofire = delays[2];
            GameObject projectile = Instantiate(bullet, barrel.position + (barrel.forward * 2), barrel.rotation);
            projectile.GetComponent<Rigidbody>().velocity = barrel.forward * projectionSpeed;
            muzzleFX.Play();
       }    
    }

    private void burstShoot() // burst shot
    {
        if(nexttimetofire <= 0)
       {
           if(burstshotCount >= 3)
           {
               nexttimetofire = delays[0];
               burstshotCount = 0;
           }
           else
           {
           nexttimetofire = 0.1f;
           }

            GameObject projectile = Instantiate(bullet, barrel.position + (barrel.forward * 2), barrel.rotation);
            projectile.GetComponent<Rigidbody>().velocity = barrel.forward * projectionSpeed;
            muzzleFX.Play();
            burstshotCount++;
       }    
    }

    private void shotgunShoot() // shotgun shot
    {
        if(nexttimetofire <= 0)
        {
            nexttimetofire = delays[1];

            for (int i = 0; i < 8; i++)
                {

                    Vector3 direction = barrel.forward;
                   
                    Vector3 spread = Vector3.zero;
                    spread += barrel.up * Random.Range(-1, 1);
                    spread += barrel.right * Random.Range(-1, 1);

                    direction += spread.normalized * Random.Range(0, 0.15f);

                    GameObject projectile = Instantiate(bullet, barrel.position + (barrel.forward * 2), 
                    Quaternion.LookRotation(Vector3.RotateTowards(barrel.forward, direction, 1,0))
                    );
                    projectile.GetComponent<Rigidbody>().velocity = direction * projectionSpeed;
                }
            muzzleFX.Play();
        }    
    }

}
