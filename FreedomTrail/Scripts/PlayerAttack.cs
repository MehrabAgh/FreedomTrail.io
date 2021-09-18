using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public enum Gun_Style
    {
        Automatic,
        Manual
    }
    public Gun_Style gunStyle;
    public GunManager gun;    

    public void manual()
    {
        gunStyle = Gun_Style.Manual;
    }
    public void Automatic()
    {
        gunStyle = Gun_Style.Automatic;
    }
    private void Update()
    {
        if (gun == null || !gun.gameObject.activeSelf)
        {
            gun = FindObjectOfType<GunManager>();
        }
        else
        {
            switch (gunStyle)
            {
                case Gun_Style.Automatic:
                    gun.Shooted();
                    break;
                case Gun_Style.Manual:
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {
                        gun.Shoot();
                    }
                    if (Input.GetKeyUp(KeyCode.Mouse0))
                    {
                        gun.Reload();
                    }
                    if (Input.touchCount > 0)
                    {
                        Touch touch = Input.GetTouch(0);
                        switch (touch.phase)
                        {
                            case TouchPhase.Began:
                                gun.Shooted();
                                break;
                            case TouchPhase.Ended:
                                gun.Reload();
                                break;
                        }
                    }
                    break;
                default:
                    break;
            }
           
        }
    }
}
